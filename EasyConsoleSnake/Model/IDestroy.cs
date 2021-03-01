using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.Model
{
    public interface IDestroy
    {
        abstract void Destroy(GameObject obj);
        void View(GameObject obj);
    }
}
