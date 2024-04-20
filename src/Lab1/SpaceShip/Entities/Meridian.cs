using Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Meridian : SpaceShip
{
    public Meridian(DeflectorModifications? deflectorModifications = null)
        : base(
            new ImpulseEngineE(),
            null,
            new MediumArmor(),
            new MediumMass(),
            new MediumDeflector(deflectorModifications ?? new DeflectorModifications()),
            new ShipModifications(new AntiNitrineEmitter()))
    { }
}