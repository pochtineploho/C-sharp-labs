using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class HddBuilder : IBuilder<Hdd>
{
    public HddBuilder()
    {
        Name = string.Empty;
        Memory = 0;
        PowerConsumption = double.NaN;
        RotationSpeed = 0;
    }

    public HddBuilder(Hdd hdd)
    {
        if (hdd is null) throw new ArgumentNullException(nameof(hdd));
        Name = hdd.Name;
        Memory = hdd.Memory;
        PowerConsumption = hdd.PowerConsumption;
        RotationSpeed = hdd.RotationSpeed;
    }

    private string Name { get; set; }
    private double Memory { get; set; }
    private double PowerConsumption { get; set; }
    private double RotationSpeed { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Memory = 0;
        PowerConsumption = double.NaN;
        RotationSpeed = 0;
    }

    public HddBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public HddBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public HddBuilder WithRotationSpeed(double rotationSpeed)
    {
        RotationSpeed = rotationSpeed <= 0
            ? throw new ArgumentOutOfRangeException(nameof(rotationSpeed))
            : rotationSpeed;

        return this;
    }

    public HddBuilder WithMemory(double memory)
    {
        Memory = memory <= 0
            ? throw new ArgumentOutOfRangeException(nameof(memory))
            : memory;

        return this;
    }

    public Hdd GetResult()
    {
        return new Hdd(Name, Memory, RotationSpeed, PowerConsumption);
    }
}