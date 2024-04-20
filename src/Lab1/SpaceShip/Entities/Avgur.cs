using Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.JumpingEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Avgur : SpaceShip
{
    public Avgur(DeflectorModifications? deflectorModifications = null)
        : base(
            new ImpulseEngineE(),
            new JumpingEngineAlpha(),
            new StrongArmor(),
            new BigMass(),
            new StrongDeflector(deflectorModifications ?? new DeflectorModifications()),
            null)
    { }
}