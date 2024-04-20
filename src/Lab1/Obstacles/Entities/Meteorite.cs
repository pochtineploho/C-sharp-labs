using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Meteorite : ObstacleBase
{
    private const int DefaultMeteoriteQuantity = 1;
    public Meteorite(int quantity = DefaultMeteoriteQuantity)
        : base(300, quantity) { }

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