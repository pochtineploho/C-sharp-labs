using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class BiosBuilder : IBuilder<Bios>
{
    public BiosBuilder()
    {
        Name = string.Empty;
        Type = BiosType.Unknown;
        Version = string.Empty;
        SupportedCpus = new List<string>();
    }

    public BiosBuilder(Bios bios)
    {
        if (bios is null) throw new ArgumentNullException(nameof(bios));
        Name = bios.Name;
        Type = bios.Type;
        Version = bios.Version;
        SupportedCpus = new List<string>(bios.SupportedCpus);
    }

    private string Name { get; set; }
    private BiosType Type { get; set; }
    private string Version { get; set; }
    private List<string> SupportedCpus { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Type = BiosType.Unknown;
        Version = string.Empty;
        SupportedCpus = new List<string>();
    }

    public BiosBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public BiosBuilder WithType(BiosType type)
    {
        Type = type == BiosType.Unknown ? throw new ArgumentNullException(nameof(type)) : type;

        return this;
    }

    public BiosBuilder WithVersion(string version)
    {
        Version = string.IsNullOrEmpty(version) ? throw new ArgumentNullException(nameof(version)) : version;

        return this;
    }

    public BiosBuilder AddSupportedCpu(string supportedCpu)
    {
        SupportedCpus.Add(supportedCpu);

        return this;
    }

    public BiosBuilder AddSupportedCpu(IReadOnlyCollection<string> supportedCpus)
    {
        if (supportedCpus is null) throw new ArgumentNullException(nameof(supportedCpus));
        foreach (string supportedCpu in supportedCpus)
            SupportedCpus.Add(supportedCpu);

        return this;
    }

    public BiosBuilder WithSupportedCpus(IReadOnlyCollection<string> supportedCpus)
    {
        SupportedCpus = new List<string>(supportedCpus);

        return this;
    }

    public Bios GetResult()
    {
        return new Bios(Name, Type, Version, SupportedCpus);
    }
}