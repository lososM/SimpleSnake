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
        static Game game = new Game(dest);
        static void Main(string[] args)
        {
            
           


            Console.SetWindowSize(game.Width,game.Height);
            Console.SetBufferSize(game.Width,game.Height);
            Console.CursorVisible = false;
            //создать яблоко, нарисовать змейку
            foreach (var wall in game.Walls)
            {
                Console.SetCursorPosition(wall.position.x, wall.position.y);
                Console.Write(wall.obj);
            }
             timer = new Timer(game.Update, null, 0, 200);
           // Update(game);
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
            Console.ReadKey();



            
            

        }
         public static void Update(object obj)
        {
           // game.Update();
        }   

    }
}
