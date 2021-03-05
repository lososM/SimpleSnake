using EasyConsoleSnake.FactoryFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public delegate void EatFood(GameObject food);
    public class Game
    {
        public EatFood eatFood;
        public static int WIDTH { get; private set; } = 80;
        public static int HEIGHT { get; private set; } = 30;
        public const char VIEW_FOOD = 'F';
        public const char VIEW_WALL = 'W';

        public GameObject[,] Walls { get; private set; }//двухмерный массив?
        public IDestroy destroy { get; }
        public Snake curSnake { get; }

        //Food have calories?
        public GameObject[,] Foods { get; private set; }
        public int CountFood { get; private set; }
        //как гарантировать, что будет сделана правильная еда?
        private IFactoryFood factoryFood { get; }
        public int Score { get; private set; }
        
        public Game(IDestroy destroy)
        {
            //Собирать данные из ini файла
            //change width and height
            Foods = new GameObject[WIDTH, HEIGHT];
            Walls = new GameObject[WIDTH, HEIGHT];
            eatFood += AddScoreAndRemoveFood;
            this.destroy = destroy;
            factoryFood = new SpawnFoodForever(this,20);
            CreateWallsAround();
            // CreateFood();
           
            var newFood = new GameObject(VIEW_FOOD, 30, 15);
            AddFood(newFood);

            curSnake = new Snake(new Vector2(WIDTH / 2, HEIGHT / 2), 3, this);
            Score = 0;
       
        }
        //public void GenereateRndFood?
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
        public void AddFood(GameObject food)
        {
            //validation food
            Foods[food.position.x, food.position.y] = food;
            destroy.View(food);
            CountFood++;

        }
       private void AddScoreAndRemoveFood(GameObject gamObj)
        {
            Score++;
            Foods[gamObj.position.x, gamObj.position.y] = null;
            CountFood--;
            destroy.Destroy(gamObj);
        }
        private void CreateWallsAround()
        {
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
        //Событие, которое происходит постоянно
        public void Update(object obj)
        {
            curSnake.Move();
            factoryFood.SpawnFood();
            
        }
    }
}
