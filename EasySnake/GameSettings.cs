using EasyConsoleSnake.FactoryFoods;
using EasyConsoleSnake.Model;

namespace EasySnake.Model
{
    public struct GameSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int st_Long { get; set; }
        public Vector2 st_Pos { get; set; }
        public int max_Food { get; set; }
        public IFactoryFood FactoryFood { get; set; }
        
        //How create walls
        //How achieve win
        //Start position snake

        public  GameSettings(int width,int height)
        {
            #region validation
            #endregion

            Width = width;
            Height = height;
            st_Long = 3;
            st_Pos = new Vector2(width / 2, height / 2);
            max_Food = Height * Width;
            FactoryFood = new EatToSpawnFood();
        }
        public GameSettings(int width,int height,
                            int st_long, Vector2 st_pos,int max_food,
                            IFactoryFood factoryFood)
        {
            #region validation
            #endregion

            Width = width;
            Height = height;
            st_Long = st_long;
            st_Pos = st_pos;
            max_Food = max_food;
            FactoryFood = factoryFood;
        }
    }
}
