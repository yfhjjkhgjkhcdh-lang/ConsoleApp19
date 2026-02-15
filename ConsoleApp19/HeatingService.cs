using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class HeatingService 
    {
        private double callcuateTotalhours(List<DailyUse> dailyUses )
        {
            double totalHours = 0;
            foreach (var dailyUse in dailyUses)
            {
                totalHours += dailyUse.workingHours;
            }
            return totalHours;

        }
        private double callcuateMedian( List<double> value)

        {
            value.Sort();
            int count = value.Count;
            if (count % 2 == 0)
            {
                // If even, average the two middle values
                return (value[count / 2 ] + value[count / 2+1]) / 2;
            }
            else
            {
                // If odd, return the middle value
                return value[count / 2];
            }


        }
        public double CalculateMonthlyAverageCost(int day, Heater heater, Houes houes1)
        {
           List <double> heaterValues = new List<double>();
            foreach (var dailyUse in houes1.dailyUses)
            {
                if (dailyUse.workingHours > 0)
                {
                    heaterValues.Add(heater.CalcuateEffect (dailyUse.heaterValue));
                }
            }
            double median = callcuateMedian(heaterValues);
            double totalHours = callcuateTotalhours(houes1.dailyUses);
            return median *( totalHours /(24* day));
        }









    }
}
