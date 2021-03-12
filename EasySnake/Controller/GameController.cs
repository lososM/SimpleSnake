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
		public int Score { get; private set; }// > 0 forever, more score, more speed
		public bool Lose { get; private set; } = false;
		public int max_Food { get; }
		//Разные условия победы
		public GameController(IViewController viewContr, GameSettings settings)
        {
			viewController = viewContr;
			Game.SetValue(settings.Width, settings.Height);

			Foods = new Food[settings.Width, settings.Height];
			Walls = new GameObject[settings.Width, settings.Height];
			settings.EngineWall.GetMapWalls(this);

			Snake = new SnakeController(this, settings.st_Pos, settings.st_Long);
			Snake.Eat += AddScoreAndRemoveFood;

			Score = 0;
			max_Food = settings.max_Food;
			settings.FactoryFood.StartFactoryFood(this);
		}

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
		public void AddFood(Food food)
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
	}
}
