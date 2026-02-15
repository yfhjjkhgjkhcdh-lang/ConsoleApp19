using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class DailyUse
    {
        private int WorkingHours;
        public int workingHours
        {
            get { return WorkingHours; }
            set {

                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("Working hours must be between 0 and 24.");
                }
                WorkingHours = value;
            }
        }
        private double HeaterValue;
        public double heaterValue
        {
            get {
                return HeaterValue; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Heater value must be positive.");
                }
                HeaterValue = value;
            }
        }
       public  DailyUse(int workingHours, double heaterValue)
        {
            this.workingHours = workingHours;
            this.heaterValue = heaterValue;
        }


    }
}
