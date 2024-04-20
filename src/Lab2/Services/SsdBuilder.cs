using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SsdBuilder : IBuilder<Ssd>
{
    public SsdBuilder()
    {
        Name = string.Empty;
        Memory = 0;
        PowerConsumption = 0;
        ConnectionType = new SsdConnectionType(SsdConnector.Unknown);
        MaxSpeed = 0;
    }

    public SsdBuilder(Ssd ssd)
    {
        if (ssd is null) throw new ArgumentNullException(nameof(ssd));
        Name = ssd.Name;
        Memory = ssd.Memory;
        PowerConsumption = ssd.PowerConsumption;
        ConnectionType = ssd.ConnectionType;
        MaxSpeed = ssd.MaxSpeed;
    }

    private string Name { get; set; }
    private double Memory { get; set; }
    private double PowerConsumption { get; set; }
    private SsdConnectionType ConnectionType { get; set; }
    private double MaxSpeed { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Memory = 0;
        PowerConsumption = 0;
        ConnectionType = new SsdConnectionType(SsdConnector.Unknown);
        MaxSpeed = 0;
    }

    public SsdBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public SsdBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public SsdBuilder WithMaxSpeed(double maxSpeed)
    {
        MaxSpeed = maxSpeed <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxSpeed))
            : maxSpeed;

        return this;
    }

    public SsdBuilder WithMemory(double memory)
    {
        Memory = memory <= 0
            ? throw new ArgumentOutOfRangeException(nameof(memory))
            : memory;

        return this;
    }

    public SsdBuilder WithConnectionType(SsdConnectionType connectionType)
    {
        if (connectionType is null) throw new ArgumentNullException(nameof(connectionType));
        if (connectionType.Connector == SsdConnector.Unknown)
            throw new ArgumentOutOfRangeException(nameof(connectionType));
        if (connectionType.PciEVersion == PcieVersion.Unknown)
            throw new ArgumentOutOfRangeException(nameof(connectionType));
        ConnectionType = connectionType;

        return this;
    }

    public Ssd GetResult()
    {
        return new Ssd(Name, Memory, MaxSpeed, ConnectionType, PowerConsumption);
    }
}