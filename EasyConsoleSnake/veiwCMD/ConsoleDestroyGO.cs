using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.veiw
{
    public class ConsoleDestroyGO : IDestroy
    {
        public void Destroy(GameObject obj)
        {
            Console.SetCursorPosition(obj.position.x, obj.position.y);
            Console.Write('\0');
        }

        public void View(GameObject obj)
        {
            //Не может превышать размер буффер консоли
            Console.SetCursorPosition(obj.position.x, obj.position.y);
            Console.Write(obj.obj);
        }
    }
}
