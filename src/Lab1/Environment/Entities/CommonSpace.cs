using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class CommonSpace : EnvironmentBase
{
    private const double DefaultDistance = 25000;
    private const double EfficiencyCoefficient = 1;

    public CommonSpace(IReadOnlyCollection<ObstacleBase>? obstacles = null, double distance = DefaultDistance)
        : base(EfficiencyCoefficient, obstacles, distance)
    {
        if (obstacles is null) return;
        if (Obstacles.Any(obstacle => obstacle is not Meteorite and not SmallAsteroid))
        {
            throw new ArgumentException("Common space can only have asteroids and meteorites");
        }
    }

    public override Results.Models.Results CountFuelAndTime(SpaceShip.Entities.SpaceShip spaceShip)
    {
        if (spaceShip is null) throw new ArgumentNullException(nameof(spaceShip));
        return new Results.Models.Results(
            spaceShip.ImpulseEngine.CountFuelAndTime(Distance, spaceShip.Mass, EfficiencyCoefficient),
            ResultCases.Success);
    }
}