using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class StrongDeflector : DeflectorBase
{
    private const int HitPoints = 3600;
    public StrongDeflector(DeflectorModifications deflectorModifications)
        : base(HitPoints, deflectorModifications) { }
}