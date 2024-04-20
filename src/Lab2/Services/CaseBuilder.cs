using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CaseBuilder : IBuilder<ComputerCase>
{
    public CaseBuilder()
    {
        Name = string.Empty;
        Length = 0;
        Width = 0;
        Height = 0;
        MaxGpuLength = 0;
        MaxCpuCoolingFacilityHeight = 0;
        MotherboardFormFactors = new List<MotherboardFormFactor>();
    }

    public CaseBuilder(ComputerCase computerComputerCase)
    {
        if (computerComputerCase is null) throw new ArgumentNullException(nameof(computerComputerCase));
        Name = computerComputerCase.Name;
        Length = computerComputerCase.Size.Length;
        Width = computerComputerCase.Size.Width;
        Height = computerComputerCase.Size.Height;
        MaxGpuLength = computerComputerCase.MaxGpuLength;
        MaxCpuCoolingFacilityHeight = 0;
        MotherboardFormFactors = new List<MotherboardFormFactor>(computerComputerCase.MotherboardFormFactor);
    }

    private string Name { get; set; }
    private double Length { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }
    private double MaxGpuLength { get; set; }
    private double MaxCpuCoolingFacilityHeight { get; set; }
    private List<MotherboardFormFactor> MotherboardFormFactors { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        Length = 0;
        Width = 0;
        Height = 0;
        MaxGpuLength = 0;
        MaxCpuCoolingFacilityHeight = 0;
        MotherboardFormFactors = new List<MotherboardFormFactor>();
    }

    public CaseBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public CaseBuilder WithLength(double length)
    {
        Length = length <= 0 ? throw new ArgumentOutOfRangeException(nameof(length)) : length;

        return this;
    }

    public CaseBuilder WithWidth(double width)
    {
        Width = width <= 0 ? throw new ArgumentOutOfRangeException(nameof(width)) : width;

        return this;
    }

    public CaseBuilder WithHeight(double height)
    {
        Height = height <= 0 ? throw new ArgumentOutOfRangeException(nameof(height)) : height;

        return this;
    }

    public CaseBuilder WithMaxGpuLength(double length)
    {
        Length = length <= 0 ? throw new ArgumentOutOfRangeException(nameof(length)) : length;

        return this;
    }

    public CaseBuilder WithMaxGpuWidth(double width)
    {
        Width = width <= 0 ? throw new ArgumentOutOfRangeException(nameof(width)) : width;

        return this;
    }

    public CaseBuilder WithMaxGpuHeight(double height)
    {
        Height = height <= 0 ? throw new ArgumentOutOfRangeException(nameof(height)) : height;

        return this;
    }

    public CaseBuilder AddMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        if (motherboardFormFactor == Models.MotherboardFormFactor.Unknown)
            throw new ArgumentOutOfRangeException(nameof(motherboardFormFactor));
        MotherboardFormFactors.Add(motherboardFormFactor);

        return this;
    }

    public CaseBuilder WithMotherboardFormFactor(IReadOnlyCollection<MotherboardFormFactor> motherboardFormFactors)
    {
        if (motherboardFormFactors is null) throw new ArgumentNullException(nameof(motherboardFormFactors));
        if (motherboardFormFactors.Contains(Models.MotherboardFormFactor.Unknown))
        {
            throw new ArgumentOutOfRangeException(nameof(motherboardFormFactors));
        }

        MotherboardFormFactors = new List<MotherboardFormFactor>(motherboardFormFactors);

        return this;
    }

    public CaseBuilder AddMotherboardFormFactor(IReadOnlyCollection<MotherboardFormFactor> motherboardFormFactors)
    {
        if (motherboardFormFactors is null) throw new ArgumentNullException(nameof(motherboardFormFactors));
        foreach (MotherboardFormFactor motherboardFormFactor in motherboardFormFactors)
        {
            if (motherboardFormFactor == Models.MotherboardFormFactor.Unknown)
                throw new ArgumentOutOfRangeException(nameof(motherboardFormFactors));
            MotherboardFormFactors.Add(motherboardFormFactor);
        }

        return this;
    }

    public ComputerCase GetResult()
    {
        return new ComputerCase(
            Name,
            new Dimensions(Length, Width, Height),
            MaxGpuLength,
            MotherboardFormFactors,
            MaxCpuCoolingFacilityHeight);
    }
}