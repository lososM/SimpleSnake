using EasyConsoleSnake.Model;
using EasySnake.Model;
using System;

namespace EasyConsoleSnake.Controller
{
    public class SnakeController
    {
        public event EventHandler<EventArgsEat> Eat = delegate { };
        public Snake snake { get; }
        GameController gameController { get; }
        public SnakeController(GameController gameController, Vector2 st_pos, int sn_long = 3)
        {
            this.gameController = gameController;

            
            sn_long--;
            snake = new Snake(st_pos);

            Roatate(Dir.Right);

            for (int x = 0; x < sn_long; x++)
            {
                gameController.viewController.View(snake.AddNextHead());
            }
        }
        public void Move() {

            var nextHead = snake.AddNextHead();

            #region hit wall
            if (gameController.isHitWalls(nextHead.position))
            {
                gameController.GameOver();
                return;
            }
            #endregion
            #region hit snake
            foreach (Node node in snake)
            {
                if (node != snake.Head && node.gamObj.position == nextHead.position) {
                    gameController.GameOver();
                    return;
                }
            }
            #endregion
            #region hit food
            if (gameController.Foods[nextHead.position.x, nextHead.position.y] != null)
            {
                var tempFood = gameController.Foods[nextHead.position.x, nextHead.position.y];

                EventArgsEat args = new EventArgsEat() { food = tempFood };
                Eat(gameController, args);

                gameController.viewController.View(nextHead);
                return;
            }
            #endregion

            gameController.viewController.View(nextHead);
            gameController.viewController.Destroy(snake.RemoveTail());
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
