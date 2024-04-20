using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class PowerSupplyBuilder : IBuilder<PowerSupply>
{
    public PowerSupplyBuilder()
    {
        Name = string.Empty;
        MaxPowerConsumption = 0;
    }

    public PowerSupplyBuilder(PowerSupply powerSupply)
    {
        if (powerSupply is null) throw new ArgumentNullException(nameof(powerSupply));
        Name = powerSupply.Name;
        MaxPowerConsumption = powerSupply.MaxPowerConsumption;
    }

    private string Name { get; set; }
    private double MaxPowerConsumption { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        MaxPowerConsumption = 0;
    }

    public PowerSupplyBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public PowerSupplyBuilder WithMaxPowerConsumption(double maxPowerConsumption)
    {
        MaxPowerConsumption = maxPowerConsumption <= 0
            ? throw new ArgumentNullException(nameof(maxPowerConsumption))
            : maxPowerConsumption;

        return this;
    }

    public PowerSupply GetResult()
    {
        return new PowerSupply(Name, MaxPowerConsumption);
    }
}