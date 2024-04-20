using System;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;

public abstract class ImpulseEngineBase
{
    protected ImpulseEngineBase(double power, double fuelConsumption)
    {
        Power = power < 0 ? throw new ArgumentOutOfRangeException(nameof(power)) : power;
        FuelConsumption = fuelConsumption < 0 ? throw new ArgumentOutOfRangeException(nameof(fuelConsumption)) : fuelConsumption;
    }

    protected double Power { get; }
    protected double FuelConsumption { get; }
    public abstract TimeFuel CountFuelAndTime(double distance, MassBase mass, double efficiencyCoefficient);
}