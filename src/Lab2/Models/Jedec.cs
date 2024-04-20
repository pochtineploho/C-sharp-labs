using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Jedec
{
    public Jedec(double frequency, double casLatency, Timings timing, double voltage)
    {
        Frequency = frequency <= 0 ? throw new ArgumentOutOfRangeException(nameof(frequency)) : frequency;
        CasLatency = casLatency <= 0 ? throw new ArgumentOutOfRangeException(nameof(casLatency)) : casLatency;
        Timing = timing;
        Voltage = voltage <= 0 ? throw new ArgumentOutOfRangeException(nameof(voltage)) : voltage;
    }

    public double Frequency { get; }
    public double CasLatency { get; }
    public Timings Timing { get; }
    public double Voltage { get; }
}