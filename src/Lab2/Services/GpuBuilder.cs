using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class GpuBuilder : IBuilder<Gpu>
{
    public GpuBuilder()
    {
        Name = string.Empty;
        PowerConsumption = 0;
        VideoMemory = 0;
        Frequency = 0;
        PcieVersion = PcieVersion.Unknown;
        Length = 0;
        Width = 0;
        Height = 0;
    }

    public GpuBuilder(Gpu gpu)
    {
        if (gpu is null) throw new ArgumentNullException(nameof(gpu));
        Name = gpu.Name;
        PowerConsumption = gpu.PowerConsumption;
        VideoMemory = gpu.VideoMemory;
        Frequency = gpu.Frequency;
        PcieVersion = gpu.PcieVersion;
        Length = gpu.Size.Length;
        Width = gpu.Size.Width;
        Height = gpu.Size.Height;
    }

    private string Name { get; set; }
    private double PowerConsumption { get; set; }
    private double VideoMemory { get; set; }
    private double Frequency { get; set; }
    private PcieVersion PcieVersion { get; set; }
    private double Length { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        PowerConsumption = 0;
        VideoMemory = 0;
        Frequency = 0;
        PcieVersion = PcieVersion.Unknown;
        Length = 0;
        Width = 0;
        Height = 0;
    }

    public GpuBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public GpuBuilder WithPowerConsumption(double powerConsumption)
    {
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentOutOfRangeException(nameof(powerConsumption))
            : powerConsumption;

        return this;
    }

    public GpuBuilder WithFrequency(double frequency)
    {
        Frequency = frequency <= 0
            ? throw new ArgumentOutOfRangeException(nameof(frequency))
            : frequency;

        return this;
    }

    public GpuBuilder WithVideoMemory(double videoMemory)
    {
        VideoMemory = videoMemory <= 0
            ? throw new ArgumentOutOfRangeException(nameof(videoMemory))
            : videoMemory;

        return this;
    }

    public GpuBuilder WithPciEVersion(PcieVersion pcieVersion)
    {
        PcieVersion = pcieVersion == PcieVersion.Unknown
            ? throw new ArgumentNullException(nameof(pcieVersion))
            : pcieVersion;

        return this;
    }

    public GpuBuilder WithLength(double length)
    {
        Length = length <= 0 ? throw new ArgumentOutOfRangeException(nameof(length)) : length;

        return this;
    }

    public GpuBuilder WithWidth(double width)
    {
        Width = width <= 0 ? throw new ArgumentOutOfRangeException(nameof(width)) : width;

        return this;
    }

    public GpuBuilder WithHeight(double height)
    {
        Height = height <= 0 ? throw new ArgumentOutOfRangeException(nameof(height)) : height;

        return this;
    }

    public Gpu GetResult()
    {
        return new Gpu(
            Name,
            PowerConsumption,
            VideoMemory,
            Frequency,
            PcieVersion,
            new Dimensions(Length, Width, Height));
    }
}