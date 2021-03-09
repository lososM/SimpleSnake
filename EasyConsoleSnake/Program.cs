
using System;
using System.Threading;
using EasyConsoleSnake.Model;
using EasyConsoleSnake.veiw;

namespace EasyConsoleSnake
{
    class Program
    {
        static Timer timer;
        static ConsoleCMDView viewCMD = new ConsoleCMDView();
        static GameController game ;
        static void Main(string[] args)
        {
            Console.SetWindowSize(GameController.WIDTH, GameController.HEIGHT);
            Console.SetBufferSize(GameController.WIDTH, GameController.HEIGHT);
            Console.CursorVisible = false;
            //foreach (var wall in game.Walls)
            //{
            //    Console.SetCursorPosition(wall.position.x, wall.position.y);
            //    Console.Write(wall.obj);
            //}
            game = new GameController(viewCMD);
            timer = new Timer(game.Update, null, 0, 100);
            //game.Update(null);
            GetDirection();
        }

        private static void GetDirection()
        {
            while (true)
            {
                var input = Console.ReadKey(false);

                ConsoleKey inputDir = input.Key;
                
                switch (inputDir)
                {
                    case ConsoleKey.UpArrow:
                            game.Snake.Roatate(Dir.Up);
                        break;
                    case ConsoleKey.RightArrow:
                            game.Snake.Roatate(Dir.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                            game.Snake.Roatate(Dir.Left);
                        break;
                    case ConsoleKey.DownArrow:
                            game.Snake.Roatate(Dir.Down);
                        break;
                }
            }
        }
    }
}
