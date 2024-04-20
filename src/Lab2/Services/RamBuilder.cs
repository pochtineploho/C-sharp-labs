using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RamBuilder : IBuilder<Ram>
{
    public RamBuilder()
    {
        Name = string.Empty;
        Memory = 0;
        DdrStandard = DdrStandard.Unknown;
        PowerConsumption = double.NaN;
        Jedecs = new List<Jedec>();
        XmpDocps = new List<Jedec>();
    }

    public RamBuilder(Ram ram)
    {
        if (ram is null) throw new ArgumentNullException(nameof(ram));
        Name = ram.Name;
        Memory = ram.Memory;
        DdrStandard = ram.DdrStandard;
        PowerConsumption = ram.PowerConsumption;
        Jedecs = new List<Jedec>(ram.Jedecs);
        XmpDocps = new List<Jedec>(ram.XmpDocps);
    }

    private string Name { get; set; }
    private double Memory { get; set; }
    private double PowerConsumption { get; set; }
    private DdrStandard DdrStandard { get; set; }
    private List<Jedec> Jedecs { get; set; }
    private List<Jedec> XmpDocps { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Memory = 0;
        DdrStandard = DdrStandard.Unknown;
        PowerConsumption = double.NaN;
        Jedecs = new List<Jedec>();
        XmpDocps = new List<Jedec>();
    }

    public RamBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public RamBuilder WithMemory(double memory)
    {
        Memory = memory <= 0 ? throw new ArgumentOutOfRangeException(nameof(memory)) : memory;

        return this;
    }

    public RamBuilder WithDdrStandard(DdrStandard ddrStandard)
    {
        DdrStandard = ddrStandard == DdrStandard.Unknown
            ? throw new ArgumentNullException(nameof(ddrStandard))
            : ddrStandard;

        return this;
    }

    public RamBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public RamBuilder AddJedec(Jedec jedec)
    {
        Jedecs.Add(jedec);

        return this;
    }

    public RamBuilder AddJedec(IReadOnlyCollection<Jedec> jedecs)
    {
        if (jedecs is null) throw new ArgumentNullException(nameof(jedecs));
        foreach (Jedec jedec in jedecs)
            XmpDocps.Add(jedec);

        return this;
    }

    public RamBuilder AddXmpDocp(Jedec xmpDocp)
    {
        XmpDocps.Add(xmpDocp);

        return this;
    }

    public RamBuilder AddXmpDocp(IReadOnlyCollection<Jedec> xmpDocps)
    {
        if (xmpDocps is null) throw new ArgumentNullException(nameof(xmpDocps));
        foreach (Jedec xmpDocp in xmpDocps)
            XmpDocps.Add(xmpDocp);

        return this;
    }

    public Ram GetResult()
    {
        return new Ram(Name, Memory, DdrStandard, Jedecs, XmpDocps, PowerConsumption);
    }
}