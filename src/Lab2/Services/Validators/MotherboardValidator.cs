using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherboardValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));

        if (!computer.ComputerCase.MotherboardFormFactor.Contains(computer.Motherboard.FormFactor))
        {
            return new ComputerValidationResult.IncompatibleComponents(
                computer,
                "Motherboard's form factor doesn't match case's form factor");
        }

        return new ComputerValidationResult.Success(computer);
    }
}