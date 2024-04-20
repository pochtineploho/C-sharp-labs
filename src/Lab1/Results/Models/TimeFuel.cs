namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public class TimeFuel
{
    public TimeFuel(double time, double activePlasma, double gravitonMatter)
    {
        Time = time;
        ActivePlasma = activePlasma;
        GravitonMatter = gravitonMatter;
    }

    public TimeFuel()
        : this(0, 0, 0)
    {
    }

    public double Time { get; private set; }
    public double ActivePlasma { get; private set; }
    public double GravitonMatter { get; private set; }

    public void Add(TimeFuel timeFuel)
    {
        if (timeFuel is null) return;
        Time += timeFuel.Time;
        ActivePlasma += timeFuel.ActivePlasma;
        GravitonMatter += timeFuel.GravitonMatter;
    }
}