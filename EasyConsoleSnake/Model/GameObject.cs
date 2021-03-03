using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class GameObject
    {
        public Vector2 position { get; set; }
        public char obj { get; }
        public GameObject(char obj)
        {
            this.obj = obj;
            position = new Vector2();
        }
        public GameObject(char obj,int x,int y)
        {
            this.obj = obj;
            position = new Vector2(x, y);
        }
        public GameObject(char obj, Vector2 pos)
        {
            this.obj = obj;
            position = pos;
        }
        //tag = змейка, еда, стена
        public void Destroy()
        {

        }
        public bool isHit(GameObject gamObj)
        {
            if (position == gamObj.position) return true;
            return false;
        }
    }
}
