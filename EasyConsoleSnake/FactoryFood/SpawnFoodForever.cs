using EasyConsoleSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleSnake.FactoryFood
{
    public class SpawnFoodForever:IFactoryFood
    {
        public int tick = 5;

        public bool SpawnFood(Game game, out GameObject food)
        {
            //на поле может быть больше  1 единицы, поэтому хранить еду одним экзэмпляром неполучится=>выбрать самую подходящую структуру данных
            throw new NotImplementedException();
        }
    }
}
