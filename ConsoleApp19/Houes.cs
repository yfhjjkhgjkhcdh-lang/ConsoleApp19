using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Houes
    {
        public Owner owner { get; }
        public List<Heater> heaters { get;  }
        public Houes(Owner owner)
        {
            this.owner = owner;
                heaters = new List<Heater>();
                dailyUses = new List<DailyUse>();
            
        }
        public void AddHeater(Heater heater)
        {
            heaters.Add(heater);
        }
        public List<DailyUse> dailyUses { get; }
        


    }
}
