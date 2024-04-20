using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class AntimatterFlares : ObstacleBase
{
    private const int DefaultFlaresQuantity = 1;
    public AntimatterFlares(int quantity = DefaultFlaresQuantity)
        : base(0, quantity) { }

    public override void DealDamage(SpaceShip.Entities.SpaceShip ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));
        for (int i = 0; i < Quantity; i++)
        {
            ship.RunInto(this);
        }
    }
}