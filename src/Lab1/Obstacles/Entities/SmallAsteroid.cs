using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class SmallAsteroid : ObstacleBase
{
    private const int DefaultSmallAsteroidQuantity = 1;

    public SmallAsteroid(int quantity = DefaultSmallAsteroidQuantity)
        : base(100, quantity) { }

    public override void DealDamage(SpaceShip.Entities.SpaceShip ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));
        int defaultDamage = Damage;
        for (int i = 0; i < Quantity; i++)
        {
            Damage = defaultDamage;
            ship.RunInto(this);
        }
    }
}