using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : ComponentBase
{
    private const double DefaultDdrPowerConsumption = 4.5;
    private const double DefaultDdr2PowerConsumption = 3.5;
    private const double DefaultDdr3WeakPowerConsumption = 2.5;
    private const double DefaultDdr3PowerfulPowerConsumption = 3.5;
    private const double DefaultDdr4PowerConsumption = 5;
    private const double DefaultDdr5PowerConsumption = 4;

    public Ram(
        string name,
        double memory,
        DdrStandard ddrStandard,
        IReadOnlyCollection<Jedec> jedecs,
        IReadOnlyCollection<Jedec> xmpDocps,
        double powerConsumption = double.NaN)
        : base(name)
    {
        Memory = memory <= 0 ? throw new ArgumentOutOfRangeException(nameof(memory)) : memory;
        DdrStandard = ddrStandard == DdrStandard.Unknown
            ? throw new ArgumentNullException(nameof(ddrStandard))
            : ddrStandard;
        Jedecs = jedecs;
        XmpDocps = xmpDocps;
        PowerConsumption = double.IsNaN(powerConsumption)
            ? ddrStandard switch
            {
                /*In RAM specifications, power consumption is usually not specified because it is much less than power consumption of other components.
                 Most often it is calculated in practice in tests. */
                DdrStandard.Ddr => DefaultDdrPowerConsumption,
                DdrStandard.Ddr2 => DefaultDdr2PowerConsumption,
                DdrStandard.Ddr3 when Jedecs.Average(jedec => jedec.Frequency) < 2400 =>
                    DefaultDdr3WeakPowerConsumption,
                DdrStandard.Ddr3 when Jedecs.Average(jedec => jedec.Frequency) >= 2400 =>
                    DefaultDdr3PowerfulPowerConsumption,
                DdrStandard.Ddr4 => DefaultDdr4PowerConsumption,
                DdrStandard.Ddr5 => DefaultDdr5PowerConsumption,
                _ => PowerConsumption,
            }
            : powerConsumption;
    }

    public double Memory { get; }
    public double PowerConsumption { get; }
    public DdrStandard DdrStandard { get; }
    public IReadOnlyCollection<Jedec> Jedecs { get; }
    public IReadOnlyCollection<Jedec> XmpDocps { get; }
}