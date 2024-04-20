namespace Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;

public class FuelMarket
{
    private const double DefaultActivePlasmaPrice = 5;
    private const double DefaultGravitonMatterPrice = 20;
    public double ActivePlasmaPrice { get; } = DefaultActivePlasmaPrice;
    public double GravitonMatterPrice { get; } = DefaultGravitonMatterPrice;

    public double CountCost(double activePlasmaVolume, double gravitonMatterVolume) =>
        (ActivePlasmaPrice * activePlasmaVolume) + (GravitonMatterPrice * gravitonMatterVolume);
}