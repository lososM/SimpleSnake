using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Snake
    {
        private Vector2 direction;
        public Dir dir { get; set; }
        private Queue<GameObject> body;
        private Game curGame;
        private GameObject head;
        public Snake(Vector2 startPos, int startLong, Game game)
        {
            body = new Queue<GameObject>();
            curGame = game;

            for (int x = -startLong; x < 0; x++)
            {
                var node = new GameObject('o', startPos.x + x, startPos.y);
                head = node;
                body.Enqueue(node);
                curGame.destroy.View(node);
            }
            Roatate(Dir.Right);
        }
        public void Move()
        {
            //создать голову на основе предыдущей и добавить её перед головой
            var nextHead = new GameObject('o', new Vector2(head.position.x + direction.x, head.position.y + direction.y));
            head = nextHead;
            body.Enqueue(head);
            curGame.destroy.View(head);

            //есть ли еда впереди?
            if(curGame.Food != null)
                if(curGame.Food.position == head.position)
                {
                    curGame.Food = null;
                    return;
                }
                     
            var s = body.Dequeue();
            curGame.destroy.Destroy(s);
               

        }
        public void Roatate(Dir dir)
        {

            switch (dir)
            {
                case Dir.Right:
                    direction = new Vector2(1, 0);
                    break;
                case Dir.Left:
                    direction = new Vector2(-1, 0);
                    break;
                case Dir.Up:
                    direction = new Vector2(0, -1);
                    break;
                case Dir.Down:
                    direction = new Vector2(0, 1);
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
