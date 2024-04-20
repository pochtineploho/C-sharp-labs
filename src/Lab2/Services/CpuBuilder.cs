using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CpuBuilder : IBuilder<Cpu>
{
    public CpuBuilder()
    {
        Name = string.Empty;
        PowerConsumption = 0;
        HeatDissipation = 0;
        Frequency = 0;
        MaxMemoryFrequency = 0;
        CoresQuantity = 0;
        HasIntegratedGraphicsProcessor = false;
        Socket = string.Empty;
    }

    public CpuBuilder(Cpu cpu)
    {
        if (cpu is null) throw new ArgumentNullException(nameof(cpu));
        Name = cpu.Name;
        PowerConsumption = cpu.PowerConsumption;
        HeatDissipation = cpu.HeatDissipation;
        Frequency = cpu.Frequency;
        MaxMemoryFrequency = cpu.MaxMemoryFrequency;
        CoresQuantity = cpu.CoresQuantity;
        HasIntegratedGraphicsProcessor = cpu.HasIntegratedGraphicsProcessor;
        Socket = cpu.Socket;
    }

    private string Name { get; set; }
    private double PowerConsumption { get; set; }
    private double HeatDissipation { get; set; }
    private double Frequency { get; set; }
    private double MaxMemoryFrequency { get; set; }
    private int CoresQuantity { get; set; }
    private bool HasIntegratedGraphicsProcessor { get; set; }
    private string Socket { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        PowerConsumption = 0;
        HeatDissipation = 0;
        Frequency = 0;
        MaxMemoryFrequency = 0;
        CoresQuantity = 0;
        HasIntegratedGraphicsProcessor = false;
        Socket = string.Empty;
    }

    public CpuBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public CpuBuilder WithSocket(string socket)
    {
        Name = string.IsNullOrEmpty(socket) ? throw new ArgumentNullException(nameof(socket)) : socket;

        return this;
    }

    public CpuBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public CpuBuilder WithHeatDissipation(double heatDissipation)
    {
        HeatDissipation = heatDissipation <= 0
            ? throw new ArgumentOutOfRangeException(nameof(heatDissipation))
            : heatDissipation;

        return this;
    }

    public CpuBuilder WithFrequency(double frequency)
    {
        Frequency = frequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(frequency))
            : frequency;

        return this;
    }

    public CpuBuilder WithMaxMemoryFrequency(double maxMemoryFrequency)
    {
        MaxMemoryFrequency = maxMemoryFrequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxMemoryFrequency))
            : maxMemoryFrequency;

        return this;
    }

    public CpuBuilder WithCoresQuantity(int coresQuantity)
    {
        CoresQuantity = coresQuantity <= 0
            ? throw new ArgumentOutOfRangeException(nameof(coresQuantity))
            : coresQuantity;

        return this;
    }

    public CpuBuilder AddIntegratedGraphicsProcessor()
    {
        HasIntegratedGraphicsProcessor = true;

        return this;
    }

    public Cpu GetResult()
    {
        return new Cpu(
            Name,
            PowerConsumption,
            HeatDissipation,
            Frequency,
            MaxMemoryFrequency,
            CoresQuantity,
            HasIntegratedGraphicsProcessor,
            Socket);
    }
}