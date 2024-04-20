using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Gpu : ComponentBase
{
    public Gpu(
        string name,
        double powerConsumption,
        double videoMemory,
        double frequency,
        PcieVersion pcieVersion,
        Dimensions size)
        : base(name)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;
        VideoMemory = videoMemory <= 0
            ? throw new ArgumentOutOfRangeException(nameof(videoMemory))
            : videoMemory;
        Frequency = frequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(frequency))
            : frequency;
        PcieVersion = pcieVersion == PcieVersion.Unknown
            ? throw new ArgumentNullException(nameof(pcieVersion))
            : pcieVersion;
        Size = size;
    }

    public double PowerConsumption { get; }
    public double VideoMemory { get; }
    public double Frequency { get; }
    public PcieVersion PcieVersion { get; }
    public Dimensions Size { get; }
}