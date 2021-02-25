using EasyConsoleSnake.Model;
using System;
using System.Timers;

namespace EasyConsoleSnake
{
    class Program
    {
        static Timer timer;
        static Game game = new Game();
        static void Main(string[] args)
        {

            var moveDir = new Vector2(1, 0);
            while (true)
            {
                SetTimer();
                game.snake.AddNode();
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        moveDir = new Vector2(0, 1);
                        game.MoveSnake(moveDir);
                        break;
                    case ConsoleKey.Enter:
                            return;
                        break;
                        
                }
            }

            
            timer.Stop();
            timer.Dispose();

            

        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new Timer(900);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            char[,] matrix = new char[game.With, game.Height];
            foreach (var node in game.snake.GetAll())
            {
                matrix[node.Posittion.x, node.Posittion.y] = node.form;
            }

            var txt = "";
            for (int i = 0; i < game.With; i++) txt += "--";
            txt += "\n";


            for (int y = 0; y < game.Height; y++)
            {
                txt += "|";
                for (int x = 0; x < game.With; x++)
                {
                    txt += " " + matrix[x, y];
                }

                txt += "|\n";
            }

            for (int i = 0; i < game.With; i++) txt += "--";
            Console.WriteLine(txt);
        }
    }
}
