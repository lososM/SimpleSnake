using EasyConsoleSnake.Controller;
using EasyConsoleSnake.FactoryFoods;
using EasySnake.Model;
using System;

namespace EasyConsoleSnake.Model
{
	public class GameController
	{

		public event EventHandler EventUpdate = delegate { };
		public event EventHandler EventGameOver = delegate { };

		public SnakeController Snake { get; }

		public GameObject[,] Walls { get; private set; }
		public Food[,] Foods { get; private set; }

		public IViewController viewController { get; }

		public int CountFood { get; private set; }
		public int Score { get; private set; }// > 0 forever
		public bool Lose { get; private set; } = false;
		public int max_Food { get; }
		//Разные условия победы
		public GameController(IViewController viewContr, GameSettings settings)
        {
			viewController = viewContr;
			Game.SetValue(settings.Width, settings.Height);

			Foods = new Food[settings.Width, settings.Height];
			Walls = new GameObject[settings.Width, settings.Height];

			Snake = new SnakeController(this, settings.st_Pos, settings.st_Long);
			Snake.Eat += AddScoreAndRemoveFood;
			//Получить множество стен и отрисовать их
			settings.EngineWall.GetMapWalls(this);

			//CreateWallsAround();

			Score = 0;
			max_Food = settings.max_Food;
			settings.FactoryFood.StartFactoryFood(this);
		}

		//Событие, которое происходит постоянно
		public void Update(object obj)
		{
			if (!Lose)
			{
				EventUpdate(this,null);
				Snake.Move();
			}
		}
		public void GameOver()
		{
			Lose = true;
			EventGameOver(this,null);
		}
		public void Restart() { 
		}
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
		public void AddFood(Food food)//(Food food)
		{
			//validation food
			Foods[food.gamObj.position.x, food.gamObj.position.y] = food;
			viewController.View(food.gamObj);
			CountFood++;

		}
	   private void AddScoreAndRemoveFood(object sender,EventArgsEat eventArgs)
		{
			Foods[eventArgs.food.gamObj.position.x, eventArgs.food.gamObj.position.y] = null;
			viewController.Destroy(eventArgs.food.gamObj);
			Score+=eventArgs.food.Calories;
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
					block = new GameObject(Game.VIEW_WALL, new Vector2((i + StartPos.x) * dir.x, StartPos.y));

				if(dir.x == 0)
					block = new GameObject(Game.VIEW_WALL, new Vector2(StartPos.x, (i + StartPos.y) * dir.y));
				Walls[block.position.x, block.position.y] = block;
				viewController.View(block);
				//Walls.TryAdd(block.GetHashCode(), block);
			   
			}
		}
	}
}
