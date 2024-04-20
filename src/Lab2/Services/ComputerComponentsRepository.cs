using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerComponentsRepository
{
    public ComputerComponentsRepository(
        BiosRepository biosRepository,
        CaseRepository caseRepository,
        CpuRepository cpuRepository,
        GpuRepository gpuRepository,
        HddRepository hddRepository,
        MotherboardRepository motherboardRepository,
        PowerSupplyRepository powerSupplyRepository,
        RamRepository ramRepository,
        SsdRepository ssdRepository,
        WifiAdapterRepository wifiAdapterRepository,
        CpuCoolingFacilityRepository cpuCoolingFacilityRepository)
    {
        BiosRepository = biosRepository ?? throw new ArgumentNullException(nameof(biosRepository));
        CaseRepository = caseRepository ?? throw new ArgumentNullException(nameof(caseRepository));
        CpuRepository = cpuRepository ?? throw new ArgumentNullException(nameof(cpuRepository));
        GpuRepository = gpuRepository ?? throw new ArgumentNullException(nameof(gpuRepository));
        HddRepository = hddRepository ?? throw new ArgumentNullException(nameof(hddRepository));
        MotherboardRepository = motherboardRepository ?? throw new ArgumentNullException(nameof(motherboardRepository));
        PowerSupplyRepository = powerSupplyRepository ?? throw new ArgumentNullException(nameof(powerSupplyRepository));
        RamRepository = ramRepository ?? throw new ArgumentNullException(nameof(ramRepository));
        SsdRepository = ssdRepository ?? throw new ArgumentNullException(nameof(ssdRepository));
        WifiAdapterRepository = wifiAdapterRepository ?? throw new ArgumentNullException(nameof(wifiAdapterRepository));
        CpuCoolingFacilityRepository = cpuCoolingFacilityRepository ??
                                    throw new ArgumentNullException(nameof(cpuCoolingFacilityRepository));
    }

    private BiosRepository BiosRepository { get; }
    private CaseRepository CaseRepository { get; }
    private CpuRepository CpuRepository { get; }
    private GpuRepository GpuRepository { get; }
    private HddRepository HddRepository { get; }
    private MotherboardRepository MotherboardRepository { get; }
    private PowerSupplyRepository PowerSupplyRepository { get; }
    private RamRepository RamRepository { get; }
    private SsdRepository SsdRepository { get; }
    private WifiAdapterRepository WifiAdapterRepository { get; }
    private CpuCoolingFacilityRepository CpuCoolingFacilityRepository { get; }

    public Bios GetBiosByName(string name) => BiosRepository.GetByName(name);
    public ComputerCase GetCaseByName(string name) => CaseRepository.GetByName(name);
    public Cpu GetCpuByName(string name) => CpuRepository.GetByName(name);
    public Gpu GetGpuByName(string name) => GpuRepository.GetByName(name);
    public Hdd GetHddByName(string name) => HddRepository.GetByName(name);
    public Motherboard GetMotherboardByName(string name) => MotherboardRepository.GetByName(name);
    public PowerSupply GetPowerSupplyByName(string name) => PowerSupplyRepository.GetByName(name);
    public Ram GetRamByName(string name) => RamRepository.GetByName(name);
    public Ssd GetSsdByName(string name) => SsdRepository.GetByName(name);
    public WifiAdapter GetWifiAdapterByName(string name) => WifiAdapterRepository.GetByName(name);
    public CpuCoolingFacility GetCpuCoolingFacilityByName(string name) => CpuCoolingFacilityRepository.GetByName(name);

    public ComputerComponentsRepository Add(Bios component)
    {
        BiosRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(ComputerCase component)
    {
        CaseRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Cpu component)
    {
        CpuRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Gpu component)
    {
        GpuRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Hdd component)
    {
        HddRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Motherboard component)
    {
        MotherboardRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(PowerSupply component)
    {
        PowerSupplyRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Ram component)
    {
        RamRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(Ssd component)
    {
        SsdRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(WifiAdapter component)
    {
        WifiAdapterRepository.Add(component);

        return this;
    }

    public ComputerComponentsRepository Add(CpuCoolingFacility component)
    {
        CpuCoolingFacilityRepository.Add(component);

        return this;
    }
}