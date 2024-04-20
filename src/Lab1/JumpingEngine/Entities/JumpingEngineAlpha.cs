﻿using System;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.JumpingEngine.Entities;

public class JumpingEngineAlpha : JumpingEngineBase
{
    private const double SpeedCoefficient = 100;
    private const double DefaultMaxDistance = 10000;
    private const double DefaultFuelConsumption = 500;
    public JumpingEngineAlpha()
        : base(DefaultMaxDistance, DefaultFuelConsumption) { }
    public override Results.Models.Results CountFuelAndTime(double distance, MassBase mass)
    {
        if (mass is null) throw new ArgumentNullException(nameof(mass));
        if (distance > MaxDistance) return new Results.Models.Results(new TimeFuel(), ResultCases.ShipLost);
        double speed = SpeedCoefficient / mass.Mass;
        double time = distance / speed;
        double fuel = time * FuelConsumption;
        return new Results.Models.Results(new TimeFuel(time, 0, fuel), ResultCases.Success);
    }
}