using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

public class BigMass : MassBase
{
    private const double DefaultMass = 2000;
    public BigMass()
        : base(DefaultMass) { }
}