using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Vector2
    {
        public int x { get; }
        public int y { get; }
        public Vector2()
        {
            x = 0;
            y = 0;
        }
        public Vector2(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
