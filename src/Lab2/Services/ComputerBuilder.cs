using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder : IBuilder<Computer>
{
    public ComputerBuilder(ComputerComponentsRepository repository)
    {
        Cpu = null;
        Motherboard = null;
        CoolingFacility = null;
        RamSticks = new List<Ram>();
        Case = null;
        Gpu = null;
        PowerSupply = null;
        Ssds = new List<Ssd>();
        Hdds = new List<Hdd>();
        WifiAdapter = null;
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public ComputerBuilder(Computer computer, ComputerComponentsRepository repository)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        Cpu = computer.Cpu;
        Motherboard = computer.Motherboard;
        CoolingFacility = computer.CoolingFacility;
        RamSticks = new List<Ram>(computer.RamSticks);
        Case = computer.ComputerCase;
        Gpu = computer.Gpu;
        PowerSupply = computer.PowerSupply;
        Ssds = new List<Ssd>(computer.Ssds);
        Hdds = new List<Hdd>(computer.Hdds);
        WifiAdapter = computer.WifiAdapter;
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    private ComputerComponentsRepository Repository { get; }
    private Cpu? Cpu { get; set; }
    private Motherboard? Motherboard { get; set; }
    private CpuCoolingFacility? CoolingFacility { get; set; }
    private List<Ram> RamSticks { get; set; }
    private ComputerCase? Case { get; set; }
    private Gpu? Gpu { get; set; }
    private PowerSupply? PowerSupply { get; set; }
    private List<Ssd> Ssds { get; set; }
    private List<Hdd> Hdds { get; set; }
    private WifiAdapter? WifiAdapter { get; set; }

    public void Reset()
    {
        Cpu = null;
        Motherboard = null;
        CoolingFacility = null;
        RamSticks = new List<Ram>();
        Case = null;
        Gpu = null;
        PowerSupply = null;
        Ssds = new List<Ssd>();
        Hdds = new List<Hdd>();
        WifiAdapter = null;
    }

    public ComputerBuilder WithCpu(Cpu cpu)
    {
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));

        return this;
    }

    public ComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));

        return this;
    }

    public ComputerBuilder WithCpuCoolingFacility(CpuCoolingFacility cpuCoolingFacility)
    {
        CoolingFacility = cpuCoolingFacility ?? throw new ArgumentNullException(nameof(cpuCoolingFacility));

        return this;
    }

    public ComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        PowerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));

        return this;
    }

    public ComputerBuilder WithWifiAdapter(WifiAdapter? wifiAdapter)
    {
        WifiAdapter = wifiAdapter;

        return this;
    }

    public ComputerBuilder WithGpu(Gpu? gpu)
    {
        Gpu = gpu;

        return this;
    }

    public ComputerBuilder WithCase(ComputerCase computerComputerCase)
    {
        Case = computerComputerCase ?? throw new ArgumentNullException(nameof(computerComputerCase));

        return this;
    }

    public ComputerBuilder AddRam(Ram ram)
    {
        RamSticks.Add(ram);

        return this;
    }

    public ComputerBuilder WithRam(IReadOnlyCollection<Ram> ram)
    {
        RamSticks = new List<Ram>(ram ?? throw new ArgumentNullException(nameof(ram)));

        return this;
    }

    public ComputerBuilder AddRam(IReadOnlyCollection<Ram> rams)
    {
        if (rams is null) throw new ArgumentNullException(nameof(rams));
        foreach (Ram ram in rams)
            RamSticks.Add(ram);

        return this;
    }

    public ComputerBuilder AddSsd(Ssd ssd)
    {
        Ssds.Add(ssd);

        return this;
    }

    public ComputerBuilder WithSsd(IReadOnlyCollection<Ssd> ssds)
    {
        if (ssds is null) throw new ArgumentNullException(nameof(ssds));
        Ssds = new List<Ssd>(ssds);

        return this;
    }

    public ComputerBuilder AddSsd(IReadOnlyCollection<Ssd> ssds)
    {
        if (ssds is null) throw new ArgumentNullException(nameof(ssds));
        foreach (Ssd ssd in ssds)
            Ssds.Add(ssd);

        return this;
    }

    public ComputerBuilder AddHdd(Hdd hdd)
    {
        Hdds.Add(hdd);

        return this;
    }

    public ComputerBuilder WithHdd(IReadOnlyCollection<Hdd> hdds)
    {
        if (hdds is null) throw new ArgumentNullException(nameof(hdds));
        Hdds = new List<Hdd>(hdds);

        return this;
    }

    public ComputerBuilder AddHdd(IReadOnlyCollection<Hdd> hdds)
    {
        if (hdds is null) throw new ArgumentNullException(nameof(hdds));
        foreach (Hdd hdd in hdds)
            Hdds.Add(hdd);

        return this;
    }

    public Computer GetResult()
    {
        if (Cpu is null) throw new ArgumentNullException(nameof(Cpu));
        if (Motherboard is null) throw new ArgumentNullException(nameof(Motherboard));
        if (CoolingFacility is null) throw new ArgumentNullException(nameof(CoolingFacility));
        if (RamSticks.Count == 0) throw new ArgumentNullException(nameof(RamSticks));
        if (Case is null) throw new ArgumentNullException(nameof(Case));
        if (Ssds.Count == 0 && Hdds.Count == 0) throw new ArgumentNullException(nameof(Ssds));
        if (PowerSupply is null) throw new ArgumentNullException(nameof(PowerSupply));

        return new Computer(
            Cpu,
            Motherboard,
            CoolingFacility,
            RamSticks,
            Case,
            PowerSupply,
            Ssds,
            Hdds,
            Gpu,
            WifiAdapter);
    }
}