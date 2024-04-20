using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class DeflectorBase
{
    protected DeflectorBase(int healthPoints, DeflectorModifications deflectorModifications)
    {
        HealthPoints = healthPoints < 0 ? throw new ArgumentOutOfRangeException(nameof(healthPoints)) : healthPoints;
        Modifications = deflectorModifications ?? throw new ArgumentNullException(nameof(deflectorModifications));
    }

    public DeflectorModifications Modifications { get; }
    public int HealthPoints { get; private set; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null) return;
        int actual = obstacle.Damage < HealthPoints ? obstacle.Damage : HealthPoints;
        HealthPoints -= actual;
        obstacle.Damage -= actual;
    }
}