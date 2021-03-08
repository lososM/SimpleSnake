using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsoleSnake.Model
{
    public class Node
    {
        public GameObject data { get; }
        public Node nextNode { get; set; }
        public Node(Vector2 pos)
        {
            data = new GameObject(Snake.SYM_NODE, pos);
        }
    }
}
