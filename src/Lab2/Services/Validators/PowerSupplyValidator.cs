using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerSupplyValidator : IComputerValidator
{
    private const double OkPowerlack = 0.8;

    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        if (computer.PowerSupply is null) throw new ArgumentNullException(nameof(computer));

        double powerConsumption = computer.Cpu.PowerConsumption +
                                  computer.RamSticks.Sum(ramStick => ramStick.PowerConsumption) +
                                  computer.Ssds.Sum(ramStick => ramStick.PowerConsumption) +
                                  computer.Hdds.Sum(ramStick => ramStick.PowerConsumption);

        if (computer.Gpu is not null) powerConsumption += computer.Gpu.PowerConsumption;
        if (computer.WifiAdapter is not null) powerConsumption += computer.WifiAdapter.PowerConsumption;
        if (!(powerConsumption > computer.PowerSupply.MaxPowerConsumption))
            return new ComputerValidationResult.Success(computer);

        if (powerConsumption * OkPowerlack < computer.PowerSupply.MaxPowerConsumption)
        {
            return new ComputerValidationResult.Warning(
                computer,
                "Warning: power consumption is too high for this power supply unit");
        }

        return new ComputerValidationResult.IncompatibleComponents(
            computer,
            "Power of supply unit is not enough to boot this pc");
    }
}