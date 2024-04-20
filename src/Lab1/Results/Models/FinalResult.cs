namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public record FinalResult(BestResult? BestTime, BestResult? BestPrice)
{
    public BestResult? BestTime { get; } = BestTime;
    public BestResult? BestPrice { get; } = BestPrice;
}