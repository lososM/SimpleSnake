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
        public static bool operator ==(Vector2 a,Vector2 b)
        {
            if (a.x == b.x && a.y == b.y) return true;
            return false;
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            if (a.x == b.x && a.y == b.y) return false;
            return true;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            Vector2 newVal = new Vector2(a.x + b.x, a.y + b.y); 
            return newVal;
        }
        public override int GetHashCode()
        {
            string temp = x.ToString() + y.ToString();
            return int.Parse(temp);

        }
        private int ShiftWarp(int value,int positions)//current hashcode, 2 bits
        {
            positions = positions & 0x1f;//validation :)
            //переводим в uint для побитового сдвига вправо, будет выполнен логический сдвиг
            uint curNum = BitConverter.ToUInt32(BitConverter.GetBytes(value));
            uint wrap = curNum >> positions;
            return BitConverter.ToInt32(BitConverter.GetBytes((curNum << positions) | wrap)); 
            
        }
    }
}
