using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class MediumDeflector : DeflectorBase
{
    private const int HitPoints = 900;
    public MediumDeflector(DeflectorModifications deflectorModifications)
        : base(HitPoints, deflectorModifications) { }
}