using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class SpaceWhale : ObstacleBase
{
    private const int DefaultWhalesQuantity = 1;

    public SpaceWhale(int quantity = DefaultWhalesQuantity)
        : base(3600, quantity) { }

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