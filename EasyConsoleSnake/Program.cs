
using System;
using System.Threading;
using EasyConsoleSnake.Model;
using EasyConsoleSnake.veiw;
using EasySnake.Model;

namespace EasyConsoleSnake
{
    class Program
    {
        static Timer timer;

        static void Main(string[] args)
        {

            Game.SetValue(50, 30);
            Console.SetWindowSize(Game.WIDTH, Game.HEIGHT);
            Console.SetBufferSize(Game.WIDTH, Game.HEIGHT);
            Console.CursorVisible = false;

            ConsoleCMDView viewCMD = new ConsoleCMDView();
            GameController gameController = new GameController(viewCMD);

            timer = new Timer(gameController.Update, null, 0, 100);

            GetDirection(gameController);
        }

        private static void GetDirection(GameController gameController)
        {
            while (true)
            {
                var input = Console.ReadKey(false);

                ConsoleKey inputDir = input.Key;
                
                switch (inputDir)
                {
                    case ConsoleKey.UpArrow:
                        gameController.Snake.Roatate(Dir.Up);
                        break;
                    case ConsoleKey.RightArrow:
                        gameController.Snake.Roatate(Dir.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        gameController.Snake.Roatate(Dir.Left);
                        break;
                    case ConsoleKey.DownArrow:
                        gameController.Snake.Roatate(Dir.Down);
                        break;
                }
            }
        }
    }
}
