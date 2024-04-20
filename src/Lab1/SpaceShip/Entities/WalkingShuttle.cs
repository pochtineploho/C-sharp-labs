using Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class WalkingShuttle : SpaceShip
{
    public WalkingShuttle()
        : base(
            new ImpulseEngineC(),
            null,
            new WeakArmor(),
            new SmallMass(),
            new NullDeflector(),
            null)
    { }
}