using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;

public abstract class MassBase
{
    protected MassBase(double mass) => Mass = mass < 0 ? throw new ArgumentOutOfRangeException(nameof(mass)) : mass;
    public double Mass { get; }
}