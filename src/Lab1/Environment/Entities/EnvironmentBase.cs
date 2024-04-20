using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public abstract class EnvironmentBase
{
    protected EnvironmentBase(
        double impulseEngineEfficiency,
        IReadOnlyCollection<ObstacleBase>? obstacles,
        double distance)
    {
        ImpulseEngineEfficiency = impulseEngineEfficiency < 0
            ? throw new ArgumentOutOfRangeException(nameof(impulseEngineEfficiency))
            : impulseEngineEfficiency;
        Obstacles = obstacles ?? new List<ObstacleBase>();
        Distance = distance <= 0 ? throw new ArgumentOutOfRangeException(nameof(distance)) : distance;
    }

    public IReadOnlyCollection<ObstacleBase> Obstacles { get; }
    public double ImpulseEngineEfficiency { get; }
    protected double Distance { get; }
    public abstract Results.Models.Results CountFuelAndTime(SpaceShip.Entities.SpaceShip spaceShip);
}