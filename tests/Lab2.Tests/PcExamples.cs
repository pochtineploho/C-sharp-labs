using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PcExamples
{
    private static readonly List<WifiAdapter> _wifiAdapterList = new List<WifiAdapter>()
    {
        new WifiAdapter(
            "TP-LINK TL-WN781ND",
            "4(802.11n)",
            PcieVersion.PciE4),
        new WifiAdapter(
            "TP-LINK Archer TX50E",
            "4(802.11n)",
            PcieVersion.PciE4),
        new WifiAdapter(
            "ASUS ROG BuiltIn",
            "4(802.11ax)",
            PcieVersion.PciE4),
    };

    private static readonly List<Bios> _biosList = new List<Bios>()
    {
        new Bios(
            "Bios1",
            BiosType.Bios,
            "v1.68",
            new[] { "Intel Core i3-12100F", "Intel Core i9-13900K(F)" }),
        new Bios(
            "Bios2",
            BiosType.Uefi,
            "v2.4.18",
            new[] { "Intel Core i5-12400F OEM" }),
        new Bios(
            "Bios3",
            BiosType.Uefi,
            "v3.66.42",
            new[] { "Intel Core i9-13900K(F)" }),
    };

    private readonly List<ComputerCase> _caseList = new List<ComputerCase>()
    {
        new ComputerCase(
            "Accord ACC-CL915",
            new Dimensions(350, 180, 425),
            300,
            new[] { MotherboardFormFactor.Atx, MotherboardFormFactor.MicroAtx },
            160),
        new ComputerCase(
            "Zalman N5 OF Black",
            new Dimensions(437, 200, 450),
            365,
            new[] { MotherboardFormFactor.Atx, MotherboardFormFactor.MicroAtx, MotherboardFormFactor.MiniAtx },
            158),
        new ComputerCase(
            "HYPERPC CYBER Black",
            new Dimensions(647, 232, 620),
            400,
            new[] { MotherboardFormFactor.Atx, MotherboardFormFactor.MicroAtx, MotherboardFormFactor.MiniAtx },
            170),
    };

    private readonly List<CpuCoolingFacility> _cpuCoolingFacilitiesList = new List<CpuCoolingFacility>()
    {
        new CpuCoolingFacility(
            "ID-COOLING SE-802-SD",
            new Dimensions(64, 117, 116),
            95,
            new[]
            {
                "AM2, AM2+", "AM3", "AM3+", "AM4", "FM1", "FM2", "FM2+", "LGA 1150", "LGA 1151", "LGA 1151-v2",
                "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1700",
            }),
        new CpuCoolingFacility(
            "ID-COOLING SE-214-XT RING",
            new Dimensions(72, 124, 150),
            180,
            new[]
            {
                "AM4", "LGA 1150", "LGA 1151", "LGA 1151-v2",
                "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1700",
            }),
        new CpuCoolingFacility(
            "HYPERPC Cooling 360 RGB",
            new Dimensions(27, 130, 120),
            300,
            new[]
            {
                "LGA 1151", "LGA 1200", "LGA 1200", "LGA 1700", "LGA 2011", "LGA 2011-3",
            }),
    };

    private readonly List<Gpu> _gpuList = new List<Gpu>()
    {
        new Gpu(
            "AMD Radeon RX 6500 XT ASUS",
            107,
            4,
            2650,
            PcieVersion.PciE4,
            new Dimensions(201, 40, 128)),
        new Gpu(
            "Palit GeForce RTX 3070 Ti GamingPro",
            290,
            8,
            2650,
            PcieVersion.PciE4,
            new Dimensions(294, 60, 112)),
        new Gpu(
            "MSI GeForce RTX 4090 SUPRIM X",
            481,
            24,
            2235,
            PcieVersion.PciE4,
            new Dimensions(336, 78, 142)),
    };

    private readonly List<Cpu> _cpuList = new List<Cpu>()
    {
        new Cpu(
            "Intel Core i3-12100F",
            89,
            53,
            3.3,
            4800,
            4,
            false,
            "LGA 1700"),
        new Cpu(
            "Intel Core i5-12400F OEM",
            117,
            65,
            2.5,
            4800,
            6,
            false,
            "LGA 1700"),
        new Cpu(
            "Intel Core i9-13900K(F)",
            253,
            125,
            3.0,
            5600,
            24,
            true,
            "LGA 1700"),
    };

    private readonly List<Hdd> _hddList = new List<Hdd>()
    {
        new Hdd(
            "WD Blue",
            1024,
            7200),
        new Hdd(
            "Seagate BarraCuda",
            2 * 1024,
            7200),
        new Hdd(
            "Seagate Exos X",
            18 * 1024,
            7200),
    };

    private readonly List<Motherboard> _motherboardList = new List<Motherboard>()
    {
        new Motherboard(
            "ASRock H610M-HVS",
            2,
            4,
            MotherboardFormFactor.MicroAtx,
            "LGA 1700",
            new BiosRepository(_biosList).GetByName("Bios1"),
            null,
            DdrStandard.Ddr4,
            true,
            new[]
            {
                new Jedec(1333, 19, new Timings(19, 19, 43, 61), 1.2),
                new Jedec(1333, 20, new Timings(19, 19, 43, 61), 1.2),
                new Jedec(1333, 21, new Timings(19, 19, 43, 61), 1.2),
                new Jedec(1600, 16, new Timings(20, 20, 40, 62), 1.35),
            },
            new List<PcieVersion>() { PcieVersion.PciE4, PcieVersion.PciE4, }),
        new Motherboard(
            "ASUS PRIME B660M-K D4",
            2,
            4,
            MotherboardFormFactor.MicroAtx,
            "LGA 1700",
            new BiosRepository(_biosList).GetByName("Bios2"),
            null,
            DdrStandard.Ddr4,
            true,
            new[]
            {
                new Jedec(2400, 17, new Timings(17, 17, 39, 55), 1.2),
                new Jedec(3733, 19, new Timings(23, 23, 42, 88), 1.35),
                new Jedec(3600, 17, new Timings(21, 21, 39, 85), 1.35),
            },
            new List<PcieVersion>() { PcieVersion.PciE4, PcieVersion.PciE4, PcieVersion.PciE4 }),
        new Motherboard(
            "ASUS ROG MAXIMUS Z790 HERO",
            4,
            6,
            MotherboardFormFactor.Atx,
            "LGA 1700",
            new BiosRepository(_biosList).GetByName("Bios3"),
            new WifiAdapterRepository(_wifiAdapterList).GetByName("ASUS ROG BuiltIn"),
            DdrStandard.Ddr5,
            true,
            new[]
            {
                new Jedec(2400, 42, new Timings(39, 39, 77, 116), 1.1),
                new Jedec(2800, 40, new Timings(40, 40, 80, 135), 1.25),
                new Jedec(2600, 40, new Timings(40, 40, 80, 125), 1.25),
                new Jedec(2400, 38, new Timings(38, 38, 70, 116), 1.1),
            },
            new List<PcieVersion>()
            {
                PcieVersion.PciE5, PcieVersion.PciE5, PcieVersion.PciE5, PcieVersion.PciE4, PcieVersion.PciE4,
                PcieVersion.PciE4,
            }),
    };

    private readonly List<PowerSupply> _powerSuppliesList = new List<PowerSupply>()
    {
        new PowerSupply("Adrenalin Rush", 200),
        new PowerSupply("ExeGate AAA400", 400),
        new PowerSupply("Chieftec Value APB-500B8", 500),
        new PowerSupply("Chieftec Task TPS-700S", 700),
        new PowerSupply("1350W Thermaltake Toughpower GF3", 1350),
    };

    private readonly List<Ram> _ramList = new List<Ram>()
    {
        new Ram(
            "Netac Shadow II",
            8,
            DdrStandard.Ddr4,
            new[]
            {
                new Jedec(1333, 19, new Timings(19, 19, 43, 61), 1.2),
            },
            new[]
            {
                new Jedec(1600, 16, new Timings(20, 20, 40, 62), 1.35),
            }),
        new Ram(
            "Kingston FURY Beast Black",
            16,
            DdrStandard.Ddr4,
            new[]
            {
                new Jedec(2400, 17, new Timings(17, 17, 39, 55), 1.2),
            },
            new[]
            {
                new Jedec(3733, 19, new Timings(23, 23, 42, 88), 1.35),
                new Jedec(3600, 17, new Timings(21, 21, 39, 85), 1.35),
            }),
        new Ram(
            "Kingston Fury Beast RGB",
            32,
            DdrStandard.Ddr5,
            new[]
            {
                new Jedec(2400, 42, new Timings(39, 39, 77, 116), 1.1),
            },
            new[]
            {
                new Jedec(2800, 40, new Timings(40, 40, 80, 135), 1.25),
                new Jedec(2600, 40, new Timings(40, 40, 80, 125), 1.25),
                new Jedec(2400, 38, new Timings(38, 38, 70, 116), 1.1),
            }),
    };

    private readonly List<Ssd> _ssdList = new List<Ssd>()
    {
        new Ssd(
            "AMD Radeon R5 Series",
            480,
            430,
            new SsdConnectionType(SsdConnector.Sata)),
        new Ssd(
            "ADATA XPG SX8200 Pro",
            1024,
            3000,
            new SsdConnectionType(SsdConnector.Pcie, PcieVersion.PciE4),
            0.33),
        new Ssd(
            "Samsung 990 PRO 1TB",
            1024,
            6900,
            new SsdConnectionType(SsdConnector.Pcie, PcieVersion.PciE4)),
        new Ssd(
            "Samsung 990 PRO 2TB",
            2048,
            6900,
            new SsdConnectionType(SsdConnector.Pcie, PcieVersion.PciE4)),
    };

    public PcExamples()
    {
        Repository = new ComputerComponentsRepository(
            new BiosRepository(_biosList),
            new CaseRepository(_caseList),
            new CpuRepository(_cpuList),
            new GpuRepository(_gpuList),
            new HddRepository(_hddList),
            new MotherboardRepository(_motherboardList),
            new PowerSupplyRepository(_powerSuppliesList),
            new RamRepository(_ramList),
            new SsdRepository(_ssdList),
            new WifiAdapterRepository(_wifiAdapterList),
            new CpuCoolingFacilityRepository(_cpuCoolingFacilitiesList));
    }

    public ComputerComponentsRepository Repository { get; }

    public ComputerBuilder WeakPcBuilder()
    {
        return new ComputerBuilder(Repository).WithCase(Repository.GetCaseByName("Accord ACC-CL915"))
            .WithCpu(Repository.GetCpuByName("Intel Core i3-12100F"))
            .WithGpu(Repository.GetGpuByName("AMD Radeon RX 6500 XT ASUS"))
            .WithMotherboard(Repository.GetMotherboardByName("ASRock H610M-HVS"))
            .WithCpuCoolingFacility(Repository.GetCpuCoolingFacilityByName("ID-COOLING SE-802-SD"))
            .AddRam(new[] { Repository.GetRamByName("Netac Shadow II"), Repository.GetRamByName("Netac Shadow II") })
            .WithSsd(new[] { Repository.GetSsdByName("AMD Radeon R5 Series") })
            .WithPowerSupply(Repository.GetPowerSupplyByName("Chieftec Value APB-500B8"));
    }

    public ComputerBuilder NicePcBuilder()
    {
        return new ComputerBuilder(Repository).WithCase(Repository.GetCaseByName("Zalman N5 OF Black"))
            .WithCpu(Repository.GetCpuByName("Intel Core i5-12400F OEM"))
            .WithGpu(Repository.GetGpuByName("Palit GeForce RTX 3070 Ti GamingPro"))
            .WithMotherboard(Repository.GetMotherboardByName("ASUS PRIME B660M-K D4"))
            .WithCpuCoolingFacility(Repository.GetCpuCoolingFacilityByName("ID-COOLING SE-214-XT RING"))
            .AddRam(new[]
            {
                Repository.GetRamByName("Kingston FURY Beast Black"), Repository.GetRamByName("Kingston FURY Beast Black"),
            })
            .WithSsd(new[] { Repository.GetSsdByName("ADATA XPG SX8200 Pro") })
            .WithPowerSupply(Repository.GetPowerSupplyByName("Chieftec Task TPS-700S"));
    }

    public ComputerBuilder OverpricePcBuilder()
    {
        return new ComputerBuilder(Repository).WithCase(Repository.GetCaseByName("HYPERPC CYBER Black"))
            .WithCpu(Repository.GetCpuByName("Intel Core i9-13900K(F)"))
            .WithGpu(Repository.GetGpuByName("MSI GeForce RTX 4090 SUPRIM X"))
            .WithMotherboard(Repository.GetMotherboardByName("ASUS ROG MAXIMUS Z790 HERO"))
            .WithCpuCoolingFacility(Repository.GetCpuCoolingFacilityByName("HYPERPC Cooling 360 RGB"))
            .AddRam(new[]
            {
                Repository.GetRamByName("Kingston Fury Beast RGB"), Repository.GetRamByName("Kingston Fury Beast RGB"),
            })
            .WithSsd(new[]
            {
                Repository.GetSsdByName("Samsung 990 PRO 1TB"), Repository.GetSsdByName("Samsung 990 PRO 2TB"),
            })
            .WithHdd(new[] { Repository.GetHddByName("Seagate Exos X") })
            .WithPowerSupply(Repository.GetPowerSupplyByName("1350W Thermaltake Toughpower GF3"));
    }
}