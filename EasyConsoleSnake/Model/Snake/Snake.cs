using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //create new head + dir
            if(Head == null)
            {
                Head = new Node(new Vector2(Game.WIDTH/2,Game.HEIGHT/2));
                Count = 1;
                return Head.data;
            }

            var node = new Node(Head.data.position + direction);
            //curGame.destroy.View(node.data);

            Head.nextNode = node;
            if (Tail == null) Tail = Head;
            Head = node;
            Count++;
            return node.data;
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

            return node.data;
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
