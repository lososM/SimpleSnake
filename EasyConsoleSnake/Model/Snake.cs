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
        public NodeSnake Head { get; }
        public NodeSnake Tail { get; private set; }

        public Snake(Vector2 startPos)
        {
            Head = new NodeSnake(startPos);
            AddNode();
        }

        public void MoveDirection(Vector2 point)
        {
            //CreatePoint

            MoveDirection(Head, point);
        }
        void MoveDirection(NodeSnake node, Vector2 point)
        {
           
            if(node.SubNode != null)
            {
                MoveDirection(node.SubNode, node.Posittion);
            }
            node.TranslateTo(point);
        }
        public void AddNode()
        {
            var nNode = new NodeSnake();
            if (Tail == null)
            {
                //должен находится за хвостом
                nNode.Posittion = new Vector2(Head.Posittion.x - 1, Head.Posittion.y);
                Head.SubNode = nNode;
                Tail = nNode;
                return;
            }
            //учитывать препятствия
            nNode.Posittion = new Vector2(Tail.Posittion.x - 1, Tail.Posittion.y);
            Tail.SubNode = nNode;
            Tail = nNode;
        }
        public List<NodeSnake> GetAll()
        {
            return GetAll(Head);
        }
        private List<NodeSnake> GetAll(NodeSnake node)
        {
            List<NodeSnake> result = new List<NodeSnake>();
            result.Add(node);
            if (node.SubNode != null) result.AddRange(GetAll(node.SubNode));
            return result;
        }
        
        public IEnumerator GetEnumerator()
        {
            NodeSnake Node = Head;
            NodeSnake nextNode = Head.SubNode;

            yield return Node;

            if(nextNode != null)
            {
                var temp = nextNode;

                Node = nextNode;
                nextNode = nextNode.SubNode;
            }
        }
    }
}
