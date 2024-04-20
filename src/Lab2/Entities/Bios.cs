using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : ComponentBase
{
    public Bios(string name, BiosType type, string version, IReadOnlyCollection<string> supportedCpus)
        : base(name)
    {
        Type = type == BiosType.Unknown ? throw new ArgumentNullException(nameof(type)) : type;
        Version = string.IsNullOrEmpty(version) ? throw new ArgumentNullException(nameof(version)) : version;
        SupportedCpus = supportedCpus;
    }

    public IReadOnlyCollection<string> SupportedCpus { get; }
    public BiosType Type { get; }
    public string Version { get; }
}