using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    public Computer(
        Cpu cpu,
        Motherboard motherboard,
        CpuCoolingFacility coolingFacility,
        IReadOnlyCollection<Ram> ramSticks,
        ComputerCase computerComputerCase,
        PowerSupply powerSupply,
        IReadOnlyCollection<Ssd> ssds,
        IReadOnlyCollection<Hdd> hdds,
        Gpu? gpu,
        WifiAdapter? wifiAdapter)
    {
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        CoolingFacility = coolingFacility ?? throw new ArgumentNullException(nameof(coolingFacility));
        RamSticks = ramSticks ?? throw new ArgumentNullException(nameof(ramSticks));
        ComputerCase = computerComputerCase ?? throw new ArgumentNullException(nameof(computerComputerCase));
        PowerSupply = powerSupply ?? throw new ArgumentNullException(nameof(powerSupply));
        Ssds = ssds ?? new List<Ssd>();
        Hdds = hdds ?? new List<Hdd>();
        if (Ssds.Count == 0 && Hdds.Count == 0) throw new ArgumentNullException(nameof(ssds));
        Gpu = gpu;
        WifiAdapter = wifiAdapter;

        var validator = new ComputerValidator();
        ComputerValidationResult result = validator.Validate(this);
        if (result is ComputerValidationResult.IncompatibleComponents incompatibleComponents)
        {
            throw new IncompatibleComponentsException(incompatibleComponents.Comment);
        }
    }

    public Cpu Cpu { get; }
    public Motherboard Motherboard { get; }
    public CpuCoolingFacility CoolingFacility { get; }
    public IReadOnlyCollection<Ram> RamSticks { get; }
    public ComputerCase ComputerCase { get; }
    public Gpu? Gpu { get; }
    public PowerSupply PowerSupply { get; }
    public IReadOnlyCollection<Ssd> Ssds { get; }
    public IReadOnlyCollection<Hdd> Hdds { get; }
    public WifiAdapter? WifiAdapter { get; }
}