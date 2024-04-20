using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : ComponentBase
{
    public Cpu(
        string name,
        double powerConsumption,
        double heatDissipation,
        double frequency,
        double maxMemoryFrequency,
        int coresQuantity,
        bool hasIntegratedGraphicsProcessor,
        string socket)
        : base(name)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;
        HeatDissipation = heatDissipation <= 0 || heatDissipation > powerConsumption
            ? throw new ArgumentOutOfRangeException(nameof(heatDissipation))
            : heatDissipation;
        Frequency = frequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(frequency))
            : frequency;
        MaxMemoryFrequency = maxMemoryFrequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxMemoryFrequency))
            : maxMemoryFrequency;
        CoresQuantity = coresQuantity <= 0
            ? throw new ArgumentOutOfRangeException(nameof(coresQuantity))
            : coresQuantity;
        HasIntegratedGraphicsProcessor = hasIntegratedGraphicsProcessor;
        Socket = string.IsNullOrEmpty(socket) ? throw new ArgumentNullException(nameof(socket)) : socket;
    }

    public double PowerConsumption { get; }
    public double HeatDissipation { get; }
    public double Frequency { get; }
    public double MaxMemoryFrequency { get; }
    public int CoresQuantity { get; }
    public bool HasIntegratedGraphicsProcessor { get; }
    public string Socket { get; }
}