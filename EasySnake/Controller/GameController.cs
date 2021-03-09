using EasyConsoleSnake.Controller;
using EasyConsoleSnake.FactoryFood;
using EasySnake.Model;
using System;
using System.IO;
using System.Text.Json;

namespace EasyConsoleSnake.Model
{
	public delegate void EatFood(GameObject food);
	//event Update
	public class GameController
	{
		public const char VIEW_FOOD = 'F';
		public const char VIEW_WALL = 'W';

		public EatFood eatFood;
		public SnakeController Snake { get; }

		public GameObject[,] Walls { get; private set; }
		public GameObject[,] Foods { get; private set; }

		private IFactoryFood factoryFood { get; }

		public IViewController viewController { get; }


		public int CountFood { get; private set; }
		public int Score { get; private set; }
		public bool Lose { get; private set; } = false;

		public GameController(IViewController viewController)
		{
			this.viewController = viewController;

			Foods = new GameObject[Game.WIDTH, Game.HEIGHT];
			Walls = new GameObject[Game.WIDTH, Game.HEIGHT];
			Snake = new SnakeController(3, this);
			
			factoryFood = new EatToSpawnFood(this);

			eatFood += AddScoreAndRemoveFood;
			CreateWallsAround();
		   
			//Remove it
			var newFood = new GameObject(VIEW_FOOD, 30, 15);
			AddFood(newFood);


			Score = 0;
		}
		public void GameOver()
		{
			Lose = true;
		}
		public void Restart() { 
		}
		//public void GenereateFood?
		public bool isHitWalls(Vector2 position)
		{
			if ((position.x < 0 && position.x > Game.WIDTH) || 
				(position.y < 0 && position.y > Game.HEIGHT))
					throw new ArgumentException("Argument below or above the limit.", nameof(position));
		  
			var result = false;
			foreach (var item in Walls)
			{
				if(item != null)
					if (item.position == position) result = true;
			}      
			return result;
		}
		public void AddFood(GameObject food)//(Food food)
		{
			//validation food
			Foods[food.position.x, food.position.y] = food;
			viewController.View(food);
			CountFood++;

		}
	   private void AddScoreAndRemoveFood(GameObject gamObj)
		{
			Foods[gamObj.position.x, gamObj.position.y] = null;
			viewController.Destroy(gamObj);
			Score++;
			CountFood--;
		}
		private void CreateWallsAround()
		{
			Vector2 dir = new Vector2(1, 0);
			Vector2 startPos = new Vector2(0, 0);
			CreateWall(dir , startPos, Game.WIDTH);

			startPos = new Vector2(0, Game.HEIGHT-1);
			CreateWall(dir, startPos, Game.WIDTH);

			dir = new Vector2(0, 1);
			startPos = new Vector2();
			CreateWall(dir, startPos, Game.HEIGHT);

			startPos = new Vector2(Game.WIDTH - 1,0);
			CreateWall(dir, startPos, Game.HEIGHT);
		}
		private void CreateWall(Vector2 dir, Vector2 StartPos, int mlong)
		{
			for (int i = 0; i < mlong; i++)
			{
				GameObject block = null;
				if(dir.y == 0)
					block = new GameObject(VIEW_WALL, new Vector2((i + StartPos.x) * dir.x, StartPos.y));

				if(dir.x == 0)
					block = new GameObject(VIEW_WALL, new Vector2(StartPos.x, (i + StartPos.y) * dir.y));
				Walls[block.position.x, block.position.y] = block;
				viewController.View(block);
				//Walls.TryAdd(block.GetHashCode(), block);
			   
			}
		}
		//Событие, которое происходит постоянно
		public void Update(object obj)
		{
			if (!Lose)
			{
				Snake.Move();
				factoryFood.SpawnFood();
			}
		   
			
		}
	}
}
