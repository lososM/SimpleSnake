using EasyConsoleSnake.Model;
using EasySnake.Model;
using System;

namespace EasyConsoleSnake.FactoryFoods
{
    public class EatToSpawnFood: IFactoryFood
    {
        Random rnd = new Random();
        public void SpawnFood(object sender,EventArgsEat eventArgs)
        {
            if(sender is GameController gameController)
            {
                if (gameController.CountFood <= 0)
                {
                    Vector2 pos = GeneratePosition(gameController);

                    var gamObj = new GameObject(Game.VIEW_FOOD, pos);
                    var food = new Food(gamObj, 2); 
                    gameController.AddFood(food);
                }
            }                      
        }

        public void StartFactoryFood(GameController gameController)
        {
            //подписаться на event eat
            gameController.Snake.Eat += SpawnFood;
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
