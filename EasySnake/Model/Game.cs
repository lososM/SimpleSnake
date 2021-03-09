using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySnake.Model
{
    public static class Game
    {
        public static int WIDTH { get; private set; } 
        public static int HEIGHT { get;private set; }
        //когда поток запущен, получать данные из GameSettings.json
        public static void SetValue(int width,int height)
        {
            WIDTH = width;
            HEIGHT = height;
        }
        //   public int maxCountFood { get; set; }
        //public Game()
        //{
        //    WIDTH = 80;
        //    HEIGHT = 30;
        //}
    }
}
