using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class SsdConnectionType
{
    public SsdConnectionType(SsdConnector connector, PcieVersion? pcieVersion = null)
    {
        Connector = connector;
        PciEVersion = pcieVersion;
        if (connector == SsdConnector.Sata && pcieVersion is not null)
            throw new ArgumentOutOfRangeException(nameof(pcieVersion));
    }

    public SsdConnector Connector { get; }
    public PcieVersion? PciEVersion { get; }
}