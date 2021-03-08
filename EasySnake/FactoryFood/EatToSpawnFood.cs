using EasyConsoleSnake.Model;
using System;

namespace EasyConsoleSnake.FactoryFood
{
    public class EatToSpawnFood:IFactoryFood
    {
        Random rnd = new Random();
        bool Active = false;
        GameController game;
        bool OneFood = false;
        public EatToSpawnFood(GameController game)
        {
            this.game = game;
        }
        public void SpawnFood()
        {
            //Если не подписан на делегат, то подпишись
            if (!Active) game.eatFood += SpawnFood;
        }
        public void SpawnFood(GameObject food)
        {
            if(game.CountFood <= 0)
            {
                Vector2 pos = GeneratePosition();

                var newFood = new GameObject(GameController.VIEW_FOOD, pos);
                game.AddFood(newFood);
            }
            
        }
        private Vector2 GeneratePosition()
        {
            Vector2 resPos = new Vector2(rnd.Next(0, GameController.WIDTH), rnd.Next(0, GameController.HEIGHT));

            while (game.isHitWalls(resPos))
            {
                resPos = new Vector2(rnd.Next(0, GameController.WIDTH), rnd.Next(0, GameController.HEIGHT));
            }
            return resPos;
        }

    }
}
