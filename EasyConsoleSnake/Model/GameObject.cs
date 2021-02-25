using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public class GameObject
    {
        public Vector2 Posittion { get; set; }
        public char form { get; set; }
        public GameObject()
        {
            Posittion = new Vector2();
            form = '\0';
        }
        public GameObject(char form)
        {
            this.form = form;
        }

        public void TranslateTo(Vector2 point)
        {
            Posittion.x = point.x;
            Posittion.y = point.y;
        }
        public void TranslateDirection(Vector2 dir)
        {
            dir.SignValues();
            Posittion.x += dir.x;
            Posittion.y += dir.y;
        }
    }
}
