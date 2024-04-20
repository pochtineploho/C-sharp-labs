#pragma warning disable SA1118
using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : MemoryBase
{
    private const double DefaultPowerConsumptionSata = 9;
    private const double DefaultPowerConsumptionPcie = 6;

    public Ssd(
        string name,
        double memory,
        double maxSpeed,
        SsdConnectionType connectionType,
        double powerConsumption = double.NaN)
        : base(
            name,
            memory,
            double.IsNaN(powerConsumption) // this line would be too long without pragma
                ? (connectionType is null ? throw new ArgumentNullException(nameof(connectionType)) :
                    connectionType.Connector == SsdConnector.Sata ? DefaultPowerConsumptionSata :
                    DefaultPowerConsumptionPcie)
                : powerConsumption)
    {
        /* In SSD specifications, power consumption is usually not specified because it is much less than power consumption of other components.
             Most often it is calculated in practice in tests.*/
        ConnectionType = connectionType;
        MaxSpeed = maxSpeed <= 0 ? throw new ArgumentNullException(nameof(maxSpeed)) : maxSpeed;
    }

    public SsdConnectionType ConnectionType { get; }
    public double MaxSpeed { get; }
}