using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : ComponentBase
{
    public PowerSupply(string name, double maxPowerConsumption)
        : base(name)
    {
        MaxPowerConsumption = maxPowerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxPowerConsumption))
            : maxPowerConsumption;
    }

    public double MaxPowerConsumption { get; }
}