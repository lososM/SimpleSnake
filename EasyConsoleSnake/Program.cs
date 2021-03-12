
using System;
using System.Threading;
using EasyConsoleSnake.FactoryFoods;
using EasyConsoleSnake.Model;
using EasyConsoleSnake.veiw;
using EasySnake;
using EasySnake.EngineWall;
using EasySnake.Model;

namespace EasyConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create FactoryFood and Map for game
            IFactoryFood factory = new SpawnFoodForever(20);
            BaseEngineWall engineWall = new EWAround();

            //Create settings for game
            GameSettings settings = new GameSettings(40, 30, 5, new Vector2(10,2), 3, factory,engineWall);

            ConsoleCMDView viewCMD = new ConsoleCMDView();

            Console.SetWindowSize(settings.Width, settings.Height+2);
            Console.SetBufferSize(settings.Width, settings.Height+2);
            Console.CursorVisible = false;
            
            GameController gameController = new GameController(viewCMD,settings);

            gameController.Snake.Eat += delegate {
                Console.SetCursorPosition(2, Game.HEIGHT + 1);
                Console.Write(gameController.Score);
            };
            gameController.EventGameOver += delegate
            {
                //stop timer
                Console.SetCursorPosition(Game.WIDTH / 2 - 5, Game.HEIGHT / 2 );
                Console.Write("Game Over");
            };
            // or Thread.Sleep
            new Timer(gameController.Update, null, 0, 100);

            GetDirection(gameController);
        }
        private static void GetDirection(GameController gameController)
        {
            while (true)
            {
                var input = Console.ReadKey(true);

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
