using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.FactoryFood
{
    public class SpawnFoodForever:IFactoryFood
    {
        private uint max_tick = 5;
        private uint tick = 5;
        private uint max_cout_food = uint.MaxValue;
        Random rnd = new Random();
        Game game;
        public SpawnFoodForever(Game game)
        {
            this.game = game;
        }
        public SpawnFoodForever(Game game,uint max_tick)
        {
            this.game = game;
            this.max_tick = max_tick;
        }
        public void SpawnFood()
        {
            if(game.CountFood < max_cout_food)
                if(tick <= 0)
                {
                    Vector2 pos = GeneratePosition();

                    var newFood = new GameObject(Game.VIEW_FOOD, pos);
                    game.Foods[pos.x, pos.y] = newFood;
                    game.destroy.View(newFood);

                    tick = max_tick;
                }
                else
                {
                    tick--;
                }
        }

        private Vector2 GeneratePosition()
        {
            Vector2 resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));

            while (game.isHitWalls(resPos))
            {                
                resPos = new Vector2(rnd.Next(0, Game.WIDTH), rnd.Next(0, Game.HEIGHT));
            }
            return resPos;
        }
    }
}
