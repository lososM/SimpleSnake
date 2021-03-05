using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.FactoryFood
{
    public class EatToSpawnFood:IFactoryFood
    {
        Random rnd = new Random();
        bool Active = false;
        Game game;
        bool OneFood = false;
        public EatToSpawnFood(Game game)
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

                var newFood = new GameObject(Game.VIEW_FOOD, pos);
                game.AddFood(newFood);
            }
            
        }
        private Vector2 GeneratePosition()
        {
            Vector2 resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));

            while (game.isHitWalls(resPos))
            {
                //what?
                if (game.isHitWalls(resPos)) resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));
            }
            return resPos;
        }

    }
}
