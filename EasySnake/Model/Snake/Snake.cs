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
                Head = new Node(new Vector2(GameController.WIDTH/2,GameController.HEIGHT/2));
                Count = 1;
                return Head.data;
            }
            //если выходит за границы карты создать с другой стороны
            
            var node = new Node(Head.data.position + direction);

            if (node.data.position.x <= -1) node.data.position.x = GameController.WIDTH-1;
            if (node.data.position.x >= GameController.WIDTH) node.data.position.x = 0;
            
            if (node.data.position.y <= -1) node.data.position.y = GameController.HEIGHT-1;
            if (node.data.position.y >= GameController.HEIGHT) node.data.position.y = 0;

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
