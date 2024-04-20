using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));

        if (computer.Cpu.Socket != computer.Motherboard.Socket)
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "CPU doesn't match motherboard's socket");
        }

        if (!computer.Motherboard.Bios.SupportedCpus.Contains(computer.Cpu.Name))
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "Bios can't work with this CPU");
        }

        return new ComputerValidationResult.Success(computer);
    }
}