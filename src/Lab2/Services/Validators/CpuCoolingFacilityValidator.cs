using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuCoolingFacilityValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        if (computer.Motherboard is null) throw new ArgumentNullException(nameof(computer));
        if (computer.CoolingFacility is null) throw new ArgumentNullException(nameof(computer));

        if (!computer.CoolingFacility.Size.FitsIn(computer.ComputerCase.Size) ||
            computer.CoolingFacility.Size.Height > computer.ComputerCase.MaxCpuCoolingFacilityHeight)
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "CPU cooling facility doesn't fit in the case");
        }

        if (!computer.CoolingFacility.SupportedSockets.Contains(computer.Motherboard.Socket))
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "CPU cooling facility's socket doesn't match motherboard's socket");
        }

        if (computer.CoolingFacility.MaxHeatDissipation < computer.Cpu.HeatDissipation)
        {
            return new ComputerValidationResult.DisclaimerOfWarranty(
                computer,
                "CPU heat dissipation is too high for cooling facility");
        }

        return new ComputerValidationResult.Success(computer);
    }
}