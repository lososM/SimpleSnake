using EasyConsoleSnake.Model;
using EasyConsoleSnake.veiw;
using System;
using System.Threading;

namespace EasyConsoleSnake
{
    class Program
    {
        static Timer timer;
        static ConsoleDestroyGO dest = new ConsoleDestroyGO();
        static Game game ;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Game.WIDTH, Game.HEIGHT);
            Console.SetBufferSize(Game.WIDTH, Game.HEIGHT);
            Console.CursorVisible = false;
            //foreach (var wall in game.Walls)
            //{
            //    Console.SetCursorPosition(wall.position.x, wall.position.y);
            //    Console.Write(wall.obj);
            //}
            game = new Game(dest);
            timer = new Timer(game.Update, null, 0, 100);
            GetDirection();
        }

        private static void GetDirection()
        {
            while (true)
            {
                var input = Console.ReadKey(false);
                //выбрать направление
                //изменить направление змейки
                ConsoleKey inputDir = input.Key;
                
                switch (inputDir)
                {
                    case ConsoleKey.UpArrow:
                      
                            game.curSnake.Roatate(Dir.Up);
                        break;
                    case ConsoleKey.RightArrow:
                       
                            game.curSnake.Roatate(Dir.Right);
                        break;
                    case ConsoleKey.LeftArrow:

                            game.curSnake.Roatate(Dir.Left);
                        break;
                    case ConsoleKey.DownArrow:
                            game.curSnake.Roatate(Dir.Down);
                        break;
                }
            }
        }
    }
}
