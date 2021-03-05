using EasyConsoleSnake.FactoryFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Game
    {
        public static int WIDTH { get; private set; } = 90;
        public static int HEIGHT { get; private set; } = 30;
        public const char VIEW_FOOD = 'F';
        public const char VIEW_WALL = 'W';

        public GameObject[,] Walls { get; private set; }//двухмерный массив?
        public IDestroy destroy { get; }
        public Snake curSnake { get; }
        public GameObject Food { get; private set; }
        private IFactoryFood factoryFood { get; }
        public int Score { get; private set; }

        public Game(IDestroy destroy)
        {
            //Собирать данные из ini файла
            //change width and height
          
            this.destroy = destroy;
            factoryFood = new EatToSpawnFood();
            CreateWallsAround();
            // CreateFood();
            
            var food = new GameObject(VIEW_FOOD, 40, 15);
            Food = food;
            destroy.View(food);
            curSnake = new Snake(new Vector2(WIDTH / 2, HEIGHT / 2), 3, this);
            Score = 0;
       
        }
      
        public bool isHitWalls(Vector2 position)
        {
            var result = false;
            //position не должен превышать размер карты
            foreach (var item in Walls)
            {
                if(item != null)
                    if (item.position == position) result = true;
            }      
            return result;
        }
        public void EatFood(GameObject food)
        {
            //Search this food
            Food = null;
            Score++;
        }
        private void CreateWallsAround()
        {
            Walls = new GameObject[WIDTH,HEIGHT];
            Vector2 dir = new Vector2(1, 0);
            Vector2 startPos = new Vector2(0, 0);
            CreateWall(dir , startPos, WIDTH);

            startPos = new Vector2(0, HEIGHT-1);
            CreateWall(dir, startPos, WIDTH);

            dir = new Vector2(0, 1);
            startPos = new Vector2();
            CreateWall(dir, startPos, HEIGHT);

            startPos = new Vector2(WIDTH - 1,0);
            CreateWall(dir, startPos, HEIGHT);
        }
        private void CreateWall(Vector2 dir, Vector2 StartPos, int mlong)
        {
            for (int i = 0; i < mlong; i++)
            {
                GameObject block = null;
                if(dir.y == 0)
                    block = new GameObject(VIEW_WALL, new Vector2((i + StartPos.x) * dir.x, StartPos.y));

                if(dir.x == 0)
                    block = new GameObject(VIEW_WALL, new Vector2(StartPos.x, (i + StartPos.y) * dir.y));
                Walls[block.position.x, block.position.y] = block;
                destroy.View(block);
                //Walls.TryAdd(block.GetHashCode(), block);
               
            }
        }
        public void Update(object obj)
        {
            curSnake.Move();
            if(factoryFood.SpawnFood(this,out GameObject food))
            {
                Food = food;
                destroy.View(Food);
            }
        }
    }
}
