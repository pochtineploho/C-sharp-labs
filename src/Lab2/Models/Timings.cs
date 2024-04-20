using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Timings
{
    public Timings(int rasToCas, int rasPrecharge, int tras, int trs)
    {
        RasToCas = rasToCas <= 0 ? throw new ArgumentOutOfRangeException(nameof(rasToCas)) : rasToCas;
        RasPrecharge = rasPrecharge <= 0 ? throw new ArgumentOutOfRangeException(nameof(rasPrecharge)) : rasPrecharge;
        Tras = tras <= 0 ? throw new ArgumentOutOfRangeException(nameof(tras)) : tras;
        Trs = trs <= 0 ? throw new ArgumentOutOfRangeException(nameof(trs)) : trs;
    }

    public int RasToCas { get; }
    public int RasPrecharge { get; }
    public int Tras { get; }
    public int Trs { get; }
}