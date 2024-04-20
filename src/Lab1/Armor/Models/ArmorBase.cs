using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

public abstract class ArmorBase
{
    protected ArmorBase(int healthPoints) => HealthPoints =
        healthPoints < 0 ? throw new ArgumentOutOfRangeException(nameof(healthPoints)) : healthPoints;

    public int HealthPoints { get; private set; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null) return;

        int actual = obstacle.Damage < HealthPoints ? obstacle.Damage : HealthPoints;
        HealthPoints -= actual;
        obstacle.Damage -= actual;
    }
}