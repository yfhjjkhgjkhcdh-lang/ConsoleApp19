using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Heatercas : Heater
    {
        public override double CalcuateEffect(double VALUE)
        {
            return VALUE * 0.9;
        }
    }
}
