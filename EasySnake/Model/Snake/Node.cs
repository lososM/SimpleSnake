namespace EasyConsoleSnake.Model
{
    public class Node
    {
        public GameObject gamObj { get; }
        public Node nextNode { get; set; }
        public Node(Vector2 vec)
        {
            gamObj = new GameObject(Snake.SYM_NODE, vec);
        }
    }
}
