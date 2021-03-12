using EasySnake.Model;
using System.Collections;

namespace EasyConsoleSnake.Model
{
    public class Snake:IEnumerable
    {
        public const char SYM_NODE = 'o';

        public Dir dir { get; set; }
        public Vector2 direction { get; set; }

        public Node Head { get; private set; }
        private Node Tail { get; set; }
        public int Count { get; private set; }

        public Snake()
        {
            direction = new Vector2();
        }
        public GameObject AddNextHead()
        {
            if(Head == null)
            {
                Head = new Node(new Vector2(Game.WIDTH/2, Game.HEIGHT/2));
                Count = 1;
                return Head.gamObj;
            }
            
            var node = new Node(Head.gamObj.position + direction);
            //node.gamObj.position.x % Game.WIDTH
            if (node.gamObj.position.x <= -1) node.gamObj.position.x = Game.WIDTH-1;
            if (node.gamObj.position.x >= Game.WIDTH) node.gamObj.position.x = 0;
            
            if (node.gamObj.position.y <= -1) node.gamObj.position.y = Game.HEIGHT-1;
            if (node.gamObj.position.y >= Game.HEIGHT) node.gamObj.position.y = 0;

            Head.nextNode = node;
            if (Tail == null) Tail = Head;
            Head = node;
            Count++;
            return node.gamObj;
        }
        public GameObject RemoveTail()
        {
            var node = Tail;
            if(node != null)
            {
                Tail = Tail.nextNode;
                Count--;
            }
            else
            {               
                node = Head;
                Count = 0;
                Head = null;
            }

            return node.gamObj;
        }
        public IEnumerator GetEnumerator()
        {
            Node node = Tail;
            while (true)
            {
                if (node != null)
                {
                    yield return node;
                    node = node.nextNode;
                }
                else break;   
            }
        }
    }
    public enum Dir
    {
        Left,
        Right,
        Up,
        Down
    }
}
