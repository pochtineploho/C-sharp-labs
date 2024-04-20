using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

public class SmallMass : MassBase
{
    private const double DefaultMass = 100;
    public SmallMass()
        : base(DefaultMass) { }
}