using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Mass.Entities;

public class MediumMass : MassBase
{
    private const double DefaultMass = 500;
    public MediumMass()
        : base(DefaultMass) { }
}