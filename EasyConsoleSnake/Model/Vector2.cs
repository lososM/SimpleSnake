using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2()
        {
            x = 0;
            y = 0;
        }
        public void SignValues()
        {
            x = Math.Sign(x);
            y = Math.Sign(y);
        }
        public override string ToString()
        {
            return $"(X:{x},Y:{y});";
        }
        public static Vector2 operator+(Vector2 a,Vector2 a2)
        {
            Vector2 resVal = new Vector2();
            resVal.x = a.x + a2.x;
            resVal.y = a.y + a2.y;
            return resVal;
        }
    }
}
