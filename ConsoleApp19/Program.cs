using ConsoleApp19;
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter owner name");
        string ownerName = Console.ReadLine();
        Owner owner = new Owner(ownerName);
        Houes houes = new Houes(owner);

        Heater heaterEL = new HeaterEL();
        Heater heatercas = new Heatercas();
       
        
        foreach (var item in Enum.GetValues(typeof(HeaterType)))
        {
            Console.WriteLine($"{(int)item}-{item}");
        }
        while (true)
        {
            Console.Write("Select heater type (1 or 2): ");
            int heaterType = Convert.ToInt32(Console.ReadLine());
            if (heaterType == 1)
            {
                houes.AddHeater(heaterEL);
                break;
            }
            else if (heaterType == 2)
            {
                houes.AddHeater(heatercas);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. Please enter 1 or 2.");
            }
        }


        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Enter month (1 - 12): ");
        int month = int.Parse(Console.ReadLine());

        GetDayInMonth days = new GetDayInMonth(year,
                                                         month);
        int daysInMonth = days.GetDays(year, month);

        Console.WriteLine("This month has " + daysInMonth + " days.");
        for (int i = 0; i < daysInMonth; i++)
        {
            double heaterValue;

            int workingHours;
            while (true)
            {
                Console.Write("Enter working hours for day " + (i + 1) + ": ");
                workingHours = Convert.ToInt32(Console.ReadLine());

                if (workingHours >= 0 && workingHours <= 24)
                    break;


                Console.Clear();
                Console.WriteLine("Working hours must be between 0 and 24.");

            }


            while (true)
            {
                Console.Write("Enter heater value for day " + (i + 1) + ": ");
                heaterValue = Convert.ToDouble(Console.ReadLine());

                if (heaterValue > 0)
                    break;


                Console.Clear();
                Console.WriteLine("Value must be positive.");
            }
            Console.Clear();
            DailyUse dailyUse = new DailyUse(workingHours, heaterValue);
            houes.dailyUses.Add(dailyUse);

        }
        HeatingService heatingService = new HeatingService();
        report report = new report(heatingService);
        Console.WriteLine();
        report.GenerateReport(houes, houes.heaters, daysInMonth);







    }
    enum HeaterType
    {
        Electric,
        Gas
    };
}









