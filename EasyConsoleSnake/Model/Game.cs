using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Game
    {
        public Dictionary<Vector2,GameObject> objs { get; private set; }
        public Snake snake { get; private set; }
        public int Score { get; private set; }
        public bool infinity { get; }
        public int With { get; }
        public int Height { get; }
        public Game()
        {
            //создать границы поля
            With = 30;
            Height = 30;
            infinity = false;
            Score = 0;
            snake = new Snake(new Vector2(5,5));
        }
        public void MoveSnake(Vector2 dir)
        {
            dir.SignValues();
            Vector2 point = snake.Head.Posittion + dir;
            if(objs[point] == null)
            {
                snake.MoveDirection(point);
            }else if( objs[point] is Fruit fruit)
            {
                Score++;
                //Spawn new fruit
                //Destroy this fruit
                snake.MoveDirection(point);
            }else if(objs[point] is Wall)
            {
                //dead
            }
            else if( point.x < 0 && point.x >= With ||
                point.y < 0 && point.y >= Height)
            {
                if (infinity)
                {

                }
                else
                {
                    //dead
                }
            }
            // проверить нет ли препядствий на пути, если есть яблоко, то съесть его и тд.
            // передвинуть змейку в этом направлении
        }
    }
}
