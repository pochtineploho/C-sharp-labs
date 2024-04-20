using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MemoryValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        if (computer.Motherboard is null) throw new ArgumentNullException(nameof(computer));

        int sataCounter = 0;
        sataCounter += computer.Hdds.Count;
        sataCounter += computer.Ssds.Count(ssd => ssd.ConnectionType.Connector == SsdConnector.Sata);

        if (computer.Ssds.Where(ssdBase => ssdBase.ConnectionType.Connector == SsdConnector.Pcie).Any(ssdBase =>
                computer.Ssds.Count(ssd =>
                    ssd.ConnectionType.PciEVersion == ssdBase.ConnectionType.PciEVersion) >
                computer.Motherboard.PciE.Count(pcie => pcie == ssdBase.ConnectionType.PciEVersion)))
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "Not enough PCI-E slots");
        }

        if (sataCounter > computer.Motherboard.SataSlots)
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "Not enough SATA slots");
        }

        return new ComputerValidationResult.Success(computer);
    }
}