using EasyConsoleSnake.Model;
using EasyConsoleSnake.veiw;
using System;
using System.Threading;

namespace EasyConsoleSnake
{
    class Program
    {
        static Timer timer;
        
        static void Main(string[] args)
        {
            ConsoleDestroyGO dest = new ConsoleDestroyGO();
            Game game = new Game(dest);


            Console.SetWindowSize(game.Width,game.Height);
            Console.SetBufferSize(game.Width,game.Height);
            Console.CursorVisible = false;
            //создать яблоко, нарисовать змейку
            foreach (var wall in game.Walls)
            {
                Console.SetCursorPosition(wall.position.x, wall.position.y);
                Console.Write(wall.obj);
            }
           // timer = new Timer(Update, null, 0, 200);
            Console.ReadKey();



            
            

        }
         public static void Update(object obj)
        {
            if (obj == null) Console.WriteLine("obj is null");
        }   

    }
}
