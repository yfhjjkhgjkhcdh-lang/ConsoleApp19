using ConsoleApp19;
using System;
using System.Threading.Channels;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter owner name");
        string ownerName = Console.ReadLine();
        Console.WriteLine($"Enter owner ID");
        int id=int.Parse( Console.ReadLine() );

        Owner owner = new Owner(ownerName,id);

        House houes = new House(owner);

        Heater heaterEL = new ElectricHeater ();
        Heater heatercas = new GasHeater();
        


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
                houes.Subscribe(heaterEL);
                break;
            }
            else if (heaterType == 2)
            {
                houes.AddHeater(heatercas);
                houes.Subscribe(heatercas);
                break;
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. Please enter 1 or 2.");
            }
        }
        HeatingService service = new HeatingService();
        await service.SafeOpenAsync(houes, 0);
        
        houes.Heaters[0]?.Close();

        var weatherData = await service.LoadLastMonthWeatherAsync();
        houes.DailyUses.AddRange(weatherData);


       
       
        DateTime now = DateTime.UtcNow.AddMonths(-1);
        int days = DateTime.DaysInMonth(now.Year, now.Month == 1 ? 12 : now.Month - 1);
        //Console.WriteLine();
       
        service.PrintLastMonthDailyUsageWithThreads(houes);
       await service.PrintLastMonthDailyUsageWithTasks(houes);
        report report = new report(service);
        report.GenerateReport(houes, houes.Heaters, days);










        Console.ReadKey();
    }

  

    enum HeaterType
    {
        Electric=1,
        Gas=2,
        


    };
   
}









