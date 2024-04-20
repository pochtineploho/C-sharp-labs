using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : ComponentBase
{
    public ComputerCase(
        string name,
        Dimensions size,
        double maxGpuSize,
        IReadOnlyCollection<MotherboardFormFactor> motherboardFormFactor,
        double maxCpuCoolingFacilityHeight)
        : base(name)
    {
        Size = size;
        MaxGpuLength = maxGpuSize <= 0 ? throw new ArgumentOutOfRangeException(nameof(maxGpuSize)) : maxGpuSize;
        MaxCpuCoolingFacilityHeight = maxCpuCoolingFacilityHeight <= 0
            ? throw new ArgumentOutOfRangeException(nameof(maxCpuCoolingFacilityHeight))
            : maxCpuCoolingFacilityHeight;
        if (motherboardFormFactor is null) throw new ArgumentNullException(nameof(motherboardFormFactor));
        MotherboardFormFactor = motherboardFormFactor.Count == 0
            ? throw new ArgumentNullException(nameof(motherboardFormFactor))
            : motherboardFormFactor;
    }

    public Dimensions Size { get; }
    public double MaxGpuLength { get; }
    public double MaxCpuCoolingFacilityHeight { get; }
    public IReadOnlyCollection<MotherboardFormFactor> MotherboardFormFactor { get; }
}