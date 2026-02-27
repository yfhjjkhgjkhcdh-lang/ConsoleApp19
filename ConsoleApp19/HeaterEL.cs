using ConsoleApp19;

internal class ElectricHeater : Heater
{
  

    public override double CalcuateEffect(double VALUE)
    {
        return VALUE * 0.9;
    }
}