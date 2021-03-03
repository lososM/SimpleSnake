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
        public List<GameObject> Walls { get; private set; }
        public GameObject prefFood { get; }
        public GameObject prefWall { get; }
        public IDestroy destroy { get; }
        public int Width { get; }
        public int Height { get; }
        public Snake curSnake { get; }
        public GameObject Food { get; private set; }
        private IFactoryFood factoryFood { get; }
        public int Score { get; private set; }
        
        public Game(IDestroy destroy)
        {
            //Собирать данные из ini файла
            Width = 90;
            Height = 30;
          
            this.destroy = destroy;
            prefFood = new GameObject('F');
            prefWall = new GameObject('W');
            factoryFood = new EatToSpawnFood();
            CreateWallsAround();
           // CreateFood();
            
            var food = new GameObject('F', 40, 15);
            Food = food;
            destroy.View(food);
            curSnake = new Snake(new Vector2(Width / 2, Height / 2), 3, this);
            Score = 0;
       
        }
      
        public bool isHitWalls(Vector2 position)
        {
            var result = false;
            foreach (var wall in Walls)
            {
                if (wall.position == position)
                {
                    result = true;
                }

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
            Walls = new List<GameObject>();
            Vector2 dir = new Vector2(1, 0);
            Vector2 startPos = new Vector2(0, 0);
            CreateWall(dir , startPos, Width);

            startPos = new Vector2(0, Height-1);
            CreateWall(dir, startPos, Width);

            dir = new Vector2(0, 1);
            startPos = new Vector2();
            CreateWall(dir, startPos, Height);

            startPos = new Vector2(Width-1,0);
            CreateWall(dir, startPos, Height);
        }
        private void CreateWall(Vector2 dir, Vector2 StartPos, int mlong)
        {
            for (int i = 0; i < mlong; i++)
            {
                GameObject block = null;
                if(dir.y == 0)
                    block = new GameObject(prefWall.obj, new Vector2((i + StartPos.x) * dir.x, StartPos.y));

                if(dir.x == 0)
                    block = new GameObject(prefWall.obj, new Vector2(StartPos.x, (i + StartPos.y) * dir.y));

                Walls.Add(block);

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
