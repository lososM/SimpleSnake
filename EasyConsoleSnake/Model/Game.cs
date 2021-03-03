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
        private GameObject prefFood;
        private GameObject prefWall;
        Random rnd;
        public IDestroy destroy { get;}
        public int Width { get; }
        public int Height { get; }
        public Snake curSnake { get; }
        public GameObject Food { get; set; }
        
        public Game(IDestroy destroy)
        {
            //Собирать данные из ini файла
            Width = 80;
            Height = 30;
          
            this.destroy = destroy;
            prefFood = new GameObject('F');
            prefWall = new GameObject('W');

            CreateWallsAround();
           // CreateFood();
            
            var food = new GameObject('F', 40, 15);
            Food = food;
            destroy.View(food);
            curSnake = new Snake(new Vector2(Width / 2, Height / 2), 3, this);
          
       
        }
        
        public void CreateFood()
        {
            //исключить возможность создания еды в змейку или в стене
            rnd = new Random();
            Vector2 pos = new Vector2(rnd.Next(0, Width), rnd.Next(0, Height));
            //проверить на столкновение с другими объектами
            
            while (isHitWalls(pos))
            {
                if (isHitWalls(pos)) pos = new Vector2(rnd.Next(0, Width), rnd.Next(0, Height));
            }


            var newFood = new GameObject(prefFood.obj,pos);
            Food = newFood;
            destroy.View(newFood);
        }
        bool isHitWalls(Vector2 position)
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
            if (Food == null) CreateFood();
        }
        public enum SystemFactoryFood
        {
            EatForSpawn,
            SpawnForever
        }
    }
}
