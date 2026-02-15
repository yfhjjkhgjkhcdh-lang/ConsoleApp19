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
        public void GenerateReport(Houes houes1, Heater heater, int day)
        {
            double averageCost = heatingService.CalculateMonthlyAverageCost(day, heater, houes1);
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
