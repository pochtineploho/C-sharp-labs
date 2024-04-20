using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class GpuValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        switch (computer.Gpu)
        {
            case null when !computer.Cpu.HasIntegratedGraphicsProcessor:
                return new ComputerValidationResult.IncompatibleComponents(
                    computer,
                    "There is no graphics processor");
            case null:
                return new ComputerValidationResult.Success(computer);
        }

        if (computer.Gpu.Size.Length > computer.ComputerCase.MaxGpuLength || !computer.Gpu.Size.FitsIn(computer.ComputerCase.Size))
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "GPU doesn't fit in the case");
        }

        return new ComputerValidationResult.Success(computer);
    }
}