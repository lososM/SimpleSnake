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
        public bool SpawnFood(Game game,out GameObject food)
        {
            if (game.Food == null)
            {
                Vector2 pos = new Vector2(rnd.Next(0, game.Width), rnd.Next(0, game.Height));

                while (game.isHitWalls(pos))
                {
                    if (game.isHitWalls(pos)) pos = new Vector2(rnd.Next(0, game.Width), rnd.Next(0, game.Height));
                }
                var newFood = new GameObject(game.prefFood.obj, pos);
                food = newFood;
                return true; 
            }
            else
            {
                food = null;
                return false;
            }
        }
    }
}
