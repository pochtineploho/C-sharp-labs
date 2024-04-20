using System;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;

public class ImpulseEngineC : ImpulseEngineBase
{
    private const double DefaultPower = 300;
    private const double DefaultFuelConsumption = 50;
    private const double SpeedCoefficient = 75;

    public ImpulseEngineC()
        : base(DefaultPower, DefaultFuelConsumption) { }

    public override TimeFuel CountFuelAndTime(double distance, MassBase mass, double efficiencyCoefficient)
    {
        if (mass is null) throw new ArgumentNullException(nameof(mass));
        double speed = efficiencyCoefficient * SpeedCoefficient * Power / mass.Mass;
        double time = distance / speed;
        double fuel = time * FuelConsumption;
        return new TimeFuel(time, fuel, 0);
    }
}