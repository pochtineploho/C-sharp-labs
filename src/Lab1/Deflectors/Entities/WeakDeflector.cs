using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class WeakDeflector : DeflectorBase
{
    private const int HitPoints = 300;
    public WeakDeflector(DeflectorModifications deflectorModifications)
        : base(HitPoints, deflectorModifications) { }
}