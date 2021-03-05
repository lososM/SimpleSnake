using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Snake
    {
        const char NODE = 'o';
        private Vector2 direction;
        public Dir dir { get; set; }
        private Queue<GameObject> body;
        private Game curGame;
        private GameObject head;

        public Snake(Vector2 startPos, int startLong, Game game)
        {
            direction = new Vector2(0, 0);
            body = new Queue<GameObject>();
            curGame = game;

            for (int x = -startLong; x < 0; x++)
            {
                var node = new GameObject(NODE, startPos.x + x, startPos.y);
                head = node;
                body.Enqueue(node);
                curGame.destroy.View(node);
            }
            Roatate(Dir.Right);
        }
        public void Move()
        {
            //создать голову на основе предыдущей и добавить её перед головой
            var nextHead = new GameObject(NODE, new Vector2(head.position.x + direction.x, head.position.y + direction.y));
            head = nextHead;
            body.Enqueue(head);

            //есть ли еда впереди?
            if(curGame.Foods[head.position.x, head.position.y]!=null)
            {
                var tempFood = curGame.Foods[head.position.x, head.position.y];
                if (tempFood != null)
                    if (tempFood.position == head.position)
                    {
                        //   EatFood.
                        // 
                        curGame.eatFood(tempFood);
                        curGame.destroy.View(head);
                        return;
                    }
            }
          
        
            curGame.destroy.View(head);
            var s = body.Dequeue();
            curGame.destroy.Destroy(s);
               

        }
        public void Roatate(Dir dir)
        {

            switch (dir)
            {
                case Dir.Right:
                    direction.x = 1;
                    direction.y = 0;
                    break;
                case Dir.Left:
                    direction.x = -1;
                    direction.y = 0;
                    break;
                case Dir.Up:
                    direction.x = 0;
                    direction.y = -1;
                    break;
                case Dir.Down:
                    direction.x = 0;
                    direction.y = 1;
                    break;
            }
        }

    }
    public enum Dir
    {
        Right,
        Left,
        Up,
        Down
    }
}
