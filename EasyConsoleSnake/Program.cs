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
            Vector2 a = new Vector2(5,3);
            Vector2 b = new Vector2(1,5);
            var res = a + b;
            Console.WriteLine(a+b);
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
