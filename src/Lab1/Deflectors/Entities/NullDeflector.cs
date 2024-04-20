using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class NullDeflector : DeflectorBase
{
    public NullDeflector()
        : base(0, new DeflectorModifications()) { }
}