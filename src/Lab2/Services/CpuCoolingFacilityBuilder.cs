using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CpuCoolingFacilityBuilder : IBuilder<CpuCoolingFacility>
{
    public CpuCoolingFacilityBuilder()
    {
        Name = string.Empty;
        Length = 0;
        Width = 0;
        Height = 0;
        MaxHeatDissipation = 0;
        SupportedSockets = new List<string>();
    }

    public CpuCoolingFacilityBuilder(CpuCoolingFacility cpuCoolingFacility)
    {
        if (cpuCoolingFacility is null) throw new ArgumentNullException(nameof(cpuCoolingFacility));
        Name = cpuCoolingFacility.Name;
        Length = cpuCoolingFacility.Size.Length;
        Width = cpuCoolingFacility.Size.Width;
        Height = cpuCoolingFacility.Size.Height;
        MaxHeatDissipation = cpuCoolingFacility.MaxHeatDissipation;
        SupportedSockets = new List<string>(cpuCoolingFacility.SupportedSockets);
    }

    private string Name { get; set; }
    private double Length { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }
    private double MaxHeatDissipation { get; set; }
    private List<string> SupportedSockets { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Length = 0;
        Width = 0;
        Height = 0;
        MaxHeatDissipation = 0;
        SupportedSockets = new List<string>();
    }

    public CpuCoolingFacilityBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public CpuCoolingFacilityBuilder WithLength(double length)
    {
        Length = length <= 0 ? throw new ArgumentOutOfRangeException(nameof(length)) : length;

        return this;
    }

    public CpuCoolingFacilityBuilder WithWidth(double width)
    {
        Width = width <= 0 ? throw new ArgumentOutOfRangeException(nameof(width)) : width;

        return this;
    }

    public CpuCoolingFacilityBuilder WithHeight(double height)
    {
        Height = height <= 0 ? throw new ArgumentOutOfRangeException(nameof(height)) : height;

        return this;
    }

    public CpuCoolingFacilityBuilder WithMaxHeatDissipation(double maxHeatDissipation)
    {
        MaxHeatDissipation = maxHeatDissipation <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxHeatDissipation))
            : maxHeatDissipation;

        return this;
    }

    public CpuCoolingFacilityBuilder AddSupportedSocket(string supportedSocket)
    {
        SupportedSockets.Add(supportedSocket);

        return this;
    }

    public CpuCoolingFacilityBuilder WithMemoryCompatibility(IReadOnlyCollection<string> supportedSockets)
    {
        SupportedSockets = new List<string>(supportedSockets);

        return this;
    }

    public CpuCoolingFacilityBuilder AddSupportedSocket(IReadOnlyCollection<string> supportedSockets)
    {
        if (supportedSockets is null) throw new ArgumentNullException(nameof(supportedSockets));
        foreach (string supportedSocket in supportedSockets)
            SupportedSockets.Add(supportedSocket);

        return this;
    }

    public CpuCoolingFacility GetResult()
    {
        return new CpuCoolingFacility(
            Name,
            new Dimensions(Length, Width, Height),
            MaxHeatDissipation,
            SupportedSockets);
    }
}