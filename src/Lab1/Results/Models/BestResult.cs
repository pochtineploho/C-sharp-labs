namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public record BestResult(double Time, double Price, SpaceShip.Entities.SpaceShip? SpaceShip)
{
    public double Time { get; } = Time;
    public double Price { get; } = Price;

    public SpaceShip.Entities.SpaceShip? SpaceShip { get; } = SpaceShip;
}