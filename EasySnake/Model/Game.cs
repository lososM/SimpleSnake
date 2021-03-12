namespace EasySnake.Model
{
    public static class Game
    {
        public const char VIEW_FOOD = 'F';
        public const char VIEW_WALL = 'W';

        public static int WIDTH { get; private set; } 
        public static int HEIGHT { get; private set; }
        //ссылка на GameController

        //TODO: change this
        public static void SetValue(int width,int height)
        {
            WIDTH = width;
            HEIGHT = height;
        }
    }
}
