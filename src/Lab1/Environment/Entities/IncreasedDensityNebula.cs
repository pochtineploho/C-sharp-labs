using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class IncreasedDensityNebula : EnvironmentBase
{
    private const double DefaultDistance = 50000;
    private const double EfficiencyCoefficient = 0;

    public IncreasedDensityNebula(IReadOnlyCollection<ObstacleBase>? obstacles = null, double distance = DefaultDistance)
        : base(EfficiencyCoefficient, obstacles, distance)
    {
        if (obstacles is null) return;
        if (Obstacles.Any(obstacle => obstacle is not AntimatterFlares))
        {
            throw new ArgumentException("Increased density nebula can only have antimatter flares");
        }
    }

    public override Results.Models.Results CountFuelAndTime(SpaceShip.Entities.SpaceShip spaceShip)
    {
        if (spaceShip is null) throw new ArgumentNullException(nameof(spaceShip));
        return spaceShip.JumpingEngine is null
            ? new Results.Models.Results(new TimeFuel(), ResultCases.ShipLost)
            : spaceShip.JumpingEngine.CountFuelAndTime(Distance, spaceShip.Mass);
    }
}