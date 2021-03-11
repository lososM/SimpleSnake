namespace EasySnake.Model
{
    public static class Game
    {
        public const char VIEW_FOOD = 'F';
        public const char VIEW_WALL = 'W';

        public static int WIDTH { get; private set; } 
        public static int HEIGHT { get; private set; }
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
