using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySnake.Model
{
    public class EventArgsEat:EventArgs
    {
        public Food food { get; set; }
    }
}
