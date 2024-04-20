using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingFacility : ComponentBase
{
    public CpuCoolingFacility(
        string name,
        Dimensions size,
        double maxHeatDissipation,
        IReadOnlyCollection<string> supportedSockets)
    : base(name)
    {
        if (supportedSockets is null) throw new ArgumentNullException(nameof(supportedSockets));
        Size = size;
        MaxHeatDissipation = maxHeatDissipation <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxHeatDissipation))
            : maxHeatDissipation;
        SupportedSockets = supportedSockets.Count == 0
            ? throw new ArgumentNullException(nameof(supportedSockets))
            : supportedSockets;
    }

    public Dimensions Size { get; }
    public double MaxHeatDissipation { get; }
    public IReadOnlyCollection<string> SupportedSockets { get; }
}