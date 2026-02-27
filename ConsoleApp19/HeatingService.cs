using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class HeatingService 
    {
        
        
            public async Task SafeOpenAsync(House house, int index)
            {
                var heater = house.Heaters[index];

                if (heater == null)
                    return;

                try
                {
                    heater.Open();
                }
                catch (CHeaterFailedExceptioncs)
                {
                    Console.WriteLine("Heater failed!");

                    var replacement =
                        await CityCenterService
                            .RequestReplacementAsync(heater);

                    house.Heaters[index] = replacement;

                    if (replacement != null)
                        house.Subscribe(replacement);
                }
            }
        
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
        public double CalculateMonthlyAverageCost(int day, Heater heater, House houes1)
        {
           List <double> heaterValues = new List<double>();
            foreach (var dailyUse in houes1.DailyUses)
            {
                if (dailyUse.workingHours > 0)
                {
                    heaterValues.Add(heater.CalcuateEffect (dailyUse.heaterValue));
                }
            }
            double median = callcuateMedian(heaterValues);
            // Replace this line:
            // heaterValues.Add(heater.CalcuateEffect (dailyUse.heaterValue));

            // With this line:
          
            double totalHours = callcuateTotalhours(houes1.DailyUses);
            return median *( totalHours /(24* day));
        }
        public async Task<List<DailyUse>> LoadLastMonthWeatherAsync()
        {
            using var httpClient = new HttpClient();

            DateTime now = DateTime.UtcNow;

            DateTime start = new DateTime(now.Year, now.Month, 1)
                .AddMonths(-1);

            DateTime end = new DateTime(now.Year, now.Month, 1)
                .AddDays(-1);

            string url =
                $"https://archive-api.open-meteo.com/v1/archive?" +
                $"latitude=31.0409&longitude=31.3785" +
                $"&start_date={start:yyyy-MM-dd}" +
                $"&end_date={end:yyyy-MM-dd}" +
                $"&daily=temperature_2m_max";

            var response = await httpClient.GetStringAsync(url);

            using var json = JsonDocument.Parse(response);

            var daily = json.RootElement.GetProperty("daily");

            var dates = daily.GetProperty("time").EnumerateArray();
            var temps = daily.GetProperty("temperature_2m_max")
                             .EnumerateArray();

            List<DailyUse> result = new List<DailyUse>();

            while (dates.MoveNext() && temps.MoveNext())
            {
                DateTime date =
                    DateTime.Parse(dates.Current.GetString());

                double temp = temps.Current.GetDouble();

                double heaterValue = 500+(25-temp)*10;

                result.Add(new DailyUse( 5, heaterValue,date));
            }

            return result;
        }
        public void PrintLastMonthDailyUsageWithThreads(House house)
        {
            Thread t1 = new Thread(() => printthread(house));
            Thread t2 = new Thread(() => printthread(house));



            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
        public void printthread (House house)
        {

            foreach (var u in house.DailyUses)
            {
                Console.WriteLine(
                    $"{u.Date:yyyy-MM-dd} | " +
                    $"Hours={u.workingHours} | " +
                    $"Value={u.heaterValue} | " +
                    $"Thread={Thread.CurrentThread.ManagedThreadId}");
            }


        }
       
        public async Task PrintLastMonthDailyUsageWithTasks(House house)
        {
            var task1=Task.Run(()=>printTask(house));
            var task2=Task.Run(()=>printTask(house));
            await Task.WhenAll(task1, task2);

            
           
        }
        public void printTask(House house)
        {
            foreach (var u in house.DailyUses)
            {
                Console.WriteLine(
                    $"{u.Date:yyyy-MM-dd} | " +
                    $"Hours={u.workingHours} | " +
                    $"Value={u.heaterValue} | " +
                    $"Thread={Thread.CurrentThread.ManagedThreadId} | " +
                    $"Task={Task.CurrentId}");
            }
        }












    }
}
