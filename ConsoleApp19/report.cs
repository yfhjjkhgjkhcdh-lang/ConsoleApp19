using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class report
    {
        public HeatingService heatingService { get; }
        public report(HeatingService heatingService)
        {
            this.heatingService = heatingService;
        }
        public void GenerateReport(Houes houes1, List<Heater> heater, int day)
        {
            foreach (var item in heater)
            {
                double averageCost = heatingService.CalculateMonthlyAverageCost(day, item, houes1);
                if (heater.GetType() == typeof(HeaterEL))
                {
                    Console.WriteLine("Electric Heater Report:");
                }
                else if (heater.GetType() == typeof(Heatercas))
                {
                    Console.WriteLine("Gas Heater Report:");
                }
                Console.WriteLine($"The average monthly cost of  heating is: {averageCost:C}");
            }
        }
    }
}
