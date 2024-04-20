using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> SuccessfulBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().OverpricePcBuilder().GetResult(),
        },
        new object[]
        {
            new PcExamples().NicePcBuilder().GetResult(),
        },
        new object[]
        {
            new PcExamples().WeakPcBuilder().GetResult(),
        },
    };

    public static IEnumerable<object[]> WarningPowerBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().OverpricePcBuilder()
                .WithPowerSupply(new PcExamples().Repository.GetPowerSupplyByName("Chieftec Task TPS-700S")).GetResult(),
        },
        new object[]
        {
            new PcExamples().NicePcBuilder()
                .WithPowerSupply(new PcExamples().Repository.GetPowerSupplyByName("ExeGate AAA400")).GetResult(),
        },
        new object[]
        {
            new PcExamples().WeakPcBuilder()
                .WithPowerSupply(new PcExamples().Repository.GetPowerSupplyByName("Adrenalin rush")).GetResult(),
        },
    };

    public static IEnumerable<object[]> WeakCoolerBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().OverpricePcBuilder()
                .WithCpuCoolingFacility(new PcExamples().Repository.GetCpuCoolingFacilityByName("ID-COOLING SE-802-SD"))
                .GetResult(),
        },
        new object[]
        {
            new PcExamples().WeakPcBuilder()
                .WithCpuCoolingFacility(new PcExamples().Repository.GetCpuCoolingFacilityByName("ID-COOLING SE-802-SD"))
                .WithCpu(new PcExamples().Repository.GetCpuByName("Intel Core i9-13900K(F)"))
                .GetResult(),
        },
    };

    public static IEnumerable<object[]> RamDdrBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().OverpricePcBuilder()
                .WithRam(new[] { new PcExamples().Repository.GetRamByName("Netac Shadow II") }),
        },
        new object[]
        {
            new PcExamples().WeakPcBuilder()
                .WithRam(new[] { new PcExamples().Repository.GetRamByName("Kingston Fury Beast RGB") }),
        },
        new object[]
        {
            new PcExamples().OverpricePcBuilder()
                .WithRam(new[] { new PcExamples().Repository.GetRamByName("Kingston FURY Beast Black") }),
        },
    };

    public static IEnumerable<object[]> GpuProblemsBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().NicePcBuilder()
                .WithGpu(null),
        },
        new object[]
        {
            new PcExamples().WeakPcBuilder()
                .WithGpu(new PcExamples().Repository.GetGpuByName("MSI GeForce RTX 4090 SUPRIM X")),
        },
    };

    public static IEnumerable<object[]> MemoryProblemsBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().WeakPcBuilder()
                .AddSsd(new[]
                {
                    new PcExamples().Repository.GetSsdByName("ADATA XPG SX8200 Pro"),
                    new PcExamples().Repository.GetSsdByName("ADATA XPG SX8200 Pro"),
                    new PcExamples().Repository.GetSsdByName("ADATA XPG SX8200 Pro"),
                }),
        },
    };

    public static IEnumerable<object[]> WifiAdapterProblemsBuildTestData => new List<object[]>
    {
        new object[]
        {
            new PcExamples().OverpricePcBuilder()
                .WithWifiAdapter(new PcExamples().Repository.GetWifiAdapterByName("TP-LINK Archer TX50E")),
        },
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}