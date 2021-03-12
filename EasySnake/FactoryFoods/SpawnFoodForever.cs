using EasyConsoleSnake.Model;
using EasySnake.Model;
using System;

namespace EasyConsoleSnake.FactoryFoods
{
    public class SpawnFoodForever:IFactoryFood
    {
        Random rnd = new Random();

        private uint max_tick = 10;
        private uint tick = 0;
        //List<Food> create this foods

        public SpawnFoodForever() { }
        public SpawnFoodForever(uint max_tick)
        {
            this.max_tick = max_tick;
        }
        //конструктор, который содержит возможные настройки(max_tick, other...)
        public void SpawnFood(object sender,EventArgs eventArgs)
        {
            
            if(sender is GameController gameController)
            {
                if(gameController.CountFood < gameController.max_Food)
                    if (tick <= 0)
                    {
                        Vector2 pos = GeneratePosition(gameController);

                        var gamObj = new GameObject(Game.VIEW_FOOD, pos);
                        var food = new Food(gamObj, 1); 
                        gameController.AddFood(food);

                        tick = max_tick;
                    }
                    else
                    {
                        tick--;
                    }
            }
                
        }

        public void StartFactoryFood(GameController gameController)
        {
            gameController.EventUpdate += SpawnFood;
            SpawnFood(gameController, null);
        }

        private Vector2 GeneratePosition(GameController gameController)
        {
            Vector2 resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));

            while (gameController.isHitWalls(resPos))
            {                
                resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));
            }
            return resPos;
        }
    }
}
