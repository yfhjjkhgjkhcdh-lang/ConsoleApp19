using ConsoleApp19;
using System;
using System.Threading.Tasks;

public static class CityCenterService
{
    public static async Task<Heater?> RequestReplacementAsync(
        Heater oldHeater)
    {
        await Task.Delay(1000);

        Console.WriteLine("Replacement requested.");

        if (oldHeater is ElectricHeater)
        {
            return new ElectricHeater();




               
        }

        if (oldHeater is GasHeater)
        {
            return new GasHeater();
                
        }

        return null;
    }
}