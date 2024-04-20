namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public record Results(TimeFuel TimeAndFuel, ResultCases Result)
{
    public TimeFuel TimeAndFuel { get; } = TimeAndFuel;

    public ResultCases Result { get; } = Result;
}