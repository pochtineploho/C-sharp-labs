using Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.JumpingEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas(DeflectorModifications? deflectorModifications = null)
        : base(
            new ImpulseEngineE(),
            new JumpingEngineGamma(),
            new MediumArmor(),
            new MediumMass(),
            new WeakDeflector(deflectorModifications ?? new DeflectorModifications()),
            null)
    { }
}