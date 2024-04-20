using System;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;

public class ImpulseEngineE : ImpulseEngineBase
{
    private const double DefaultPower = 300;
    private const double DefaultFuelConsumption = 500;
    public ImpulseEngineE()
        : base(DefaultPower, DefaultFuelConsumption) { }

    public override TimeFuel CountFuelAndTime(double distance, MassBase mass, double efficiencyCoefficient)
    {
        if (mass is null) throw new ArgumentNullException(nameof(mass));
        double speedCoefficient = efficiencyCoefficient * Power / mass.Mass;
        double time = double.Log(distance) / speedCoefficient;
        double fuel = time * FuelConsumption;
        return new TimeFuel(time, fuel, 0);
    }
}