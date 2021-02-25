using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class NodeSnake:GameObject
    {
        public NodeSnake SubNode { get; set; }
        public NodeSnake()
        {
            form = 'O';
        }
        public NodeSnake(Vector2 startPos):base()
        {
            Posittion = startPos;
        }
        public override string ToString()
        {
            return form.ToString();
        }
    }
}
