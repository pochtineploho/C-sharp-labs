using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class WifiAdapterBuilder : IBuilder<WifiAdapter>
{
    public WifiAdapterBuilder()
    {
        Name = string.Empty;
        PowerConsumption = double.NaN;
        WifiStandard = string.Empty;
        PciEVersion = PcieVersion.Unknown;
    }

    public WifiAdapterBuilder(WifiAdapter wifiAdapter)
    {
        if (wifiAdapter is null) throw new ArgumentNullException(nameof(wifiAdapter));
        Name = wifiAdapter.Name;
        PowerConsumption = wifiAdapter.PowerConsumption;
        WifiStandard = wifiAdapter.WifiStandard;
        PciEVersion = wifiAdapter.PciEVersion;
    }

    private string Name { get; set; }
    private double PowerConsumption { get; set; }
    private string WifiStandard { get; set; }
    private PcieVersion? PciEVersion { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        PowerConsumption = double.NaN;
        WifiStandard = string.Empty;
        PciEVersion = PcieVersion.Unknown;
    }

    public WifiAdapterBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public WifiAdapterBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public WifiAdapterBuilder WithWifiStandard(string wifiStandard)
    {
        Name = string.IsNullOrEmpty(wifiStandard)
            ? throw new ArgumentNullException(nameof(wifiStandard))
            : wifiStandard;

        return this;
    }

    public WifiAdapterBuilder WithPciEVersion(PcieVersion? pcieVersion)
    {
        PciEVersion = pcieVersion == PcieVersion.Unknown
            ? throw new ArgumentNullException(nameof(pcieVersion))
            : PciEVersion;

        return this;
    }

    public WifiAdapter GetResult()
    {
        return new WifiAdapter(Name, WifiStandard, PciEVersion, PowerConsumption);
    }
}