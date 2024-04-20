using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : MemoryBase
{
    private const double DefaultPowerConsumption = 7.5;
    public Hdd(string name, double memory, double rotationSpeed, double powerConsumption = double.NaN)
        : base(name, memory, double.IsNaN(powerConsumption) ? DefaultPowerConsumption : powerConsumption)
    {
        /* In HDD specifications, power consumption is usually not specified because it is much less than power consumption of other components.
     Most often it is calculated in practice in tests.*/
        RotationSpeed = rotationSpeed <= 0 ? throw new ArgumentNullException(nameof(rotationSpeed)) : rotationSpeed;
    }

    public double RotationSpeed { get; }
}