using System;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.JumpingEngine.Entities;

public abstract class JumpingEngineBase
{
    protected JumpingEngineBase(double maxDistance, double fuelConsumption)
    {
        MaxDistance = maxDistance <= 0 ? throw new ArgumentOutOfRangeException(nameof(maxDistance)) : maxDistance;
        FuelConsumption = fuelConsumption < 0
            ? throw new ArgumentOutOfRangeException(nameof(fuelConsumption))
            : fuelConsumption;
    }

    protected double MaxDistance { get; }
    protected double FuelConsumption { get; }
    public abstract Results.Models.Results CountFuelAndTime(double distance, MassBase mass);
}