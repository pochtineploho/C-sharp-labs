using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class MemoryBase : ComponentBase
{
    protected MemoryBase(string name, double memory, double powerConsumption)
        : base(name)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;
        Memory = memory <= 0 ? throw new ArgumentOutOfRangeException(nameof(memory)) : memory;
    }

    public double Memory { get; }
    public double PowerConsumption { get; }
}