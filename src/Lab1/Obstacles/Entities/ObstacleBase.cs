using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage, int quantity)
    {
        Damage = damage < 0 ? throw new ArgumentOutOfRangeException(nameof(damage)) : damage;
        Quantity = quantity <= 0 ? throw new ArgumentOutOfRangeException(nameof(quantity)) : quantity;
    }

    public int Damage { get; set; }
    public int Quantity { get; }
    public abstract void DealDamage(SpaceShip.Entities.SpaceShip ship);
}