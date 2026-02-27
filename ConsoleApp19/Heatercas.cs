using ConsoleApp19;

internal class GasHeater : Heater
{
    

    public override double CalcuateEffect(double v)
    {
        // Implement effect calculation logic for gas heater
        return 0.8 *v;
    }
}