using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Controller
{
    public class SnakeController
    {
        public Snake snake { get; }
        Game game { get; }
        public SnakeController(int sn_long,Game game)
        {
            this.game = game;
            snake = new Snake();

            Roatate(Dir.Right);

            for (int x = 0; x < sn_long; x++)
            {
                game.destroy.View(snake.AddNextHead());
            }
        }
        public void Move() {

            var nextHead = snake.AddNextHead();

            //hit wall
            if (game.isHitWalls(nextHead.position))
            {
                game.GameOver();
            }
            //hit snake
            foreach (Node node in snake)
            {
               if (node != snake.Head && node.data.position == nextHead.position) game.GameOver();
            }
            //hit food
            if (game.Foods[nextHead.position.x, nextHead.position.y] != null)
            {
                var tempFood = game.Foods[nextHead.position.x, nextHead.position.y];
                game.eatFood(tempFood);
                game.destroy.View(nextHead);
                return;
            }
            //default move
            game.destroy.View(nextHead);
            game.destroy.Destroy(snake.RemoveTail());
        }
        public void Roatate(Dir dir)
        {
            if (snake.dir != dir)
            {
                switch (dir)
                {
                    case Dir.Right:

                        snake.direction.x = 1;
                        snake.direction.y = 0;
                        break;

                    case Dir.Left:
                        snake.direction.x = -1;
                        snake.direction.y = 0;
                        break;

                    case Dir.Up:
                        snake.direction.x = 0;
                        snake.direction.y = -1;
                        break;

                    case Dir.Down:
                        snake.direction.x = 0;
                        snake.direction.y = 1;
                        break;
                }

                snake.dir = dir;
            }

        }
    }
}
