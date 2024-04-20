using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WifiAdapter : ComponentBase
{
    private const double DefaultPowerConsumption = 2.5;

    public WifiAdapter(
        string name,
        string wifiStandard,
        PcieVersion? pciEVersion = null,
        double powerConsumption = DefaultPowerConsumption)
    : base(name)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : double.IsNaN(powerConsumption)
                ? DefaultPowerConsumption
                : PowerConsumption;
        WifiStandard = string.IsNullOrEmpty(wifiStandard)
            ? throw new ArgumentNullException(nameof(wifiStandard))
            : wifiStandard;
        if (pciEVersion is not null)
        {
            PciEVersion = pciEVersion == PcieVersion.Unknown
                ? throw new ArgumentNullException(nameof(pciEVersion))
                : pciEVersion;
        }
    }

    public double PowerConsumption { get; }
    public string WifiStandard { get; }
    public PcieVersion? PciEVersion { get; }
}