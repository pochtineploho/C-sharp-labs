using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class OrderGenerator
{
    private readonly ComputerValidator _validator;

    public OrderGenerator(Computer computer)
    {
        _validator = new ComputerValidator();
        Result = _validator.Validate(computer);
    }

    public ComputerValidationResult Result { get; }

    public Order SendOrder()
    {
        return Result switch
        {
            ComputerValidationResult.Success success => new Order(success.Computer),
            ComputerValidationResult.IncompatibleComponents incompatibleComponents => throw new ArgumentException(
                incompatibleComponents.Comment),
            ComputerValidationResult.Warning warning => new Order(warning.Computer, warning.Comment),
            ComputerValidationResult.DisclaimerOfWarranty disclaimerOfWarranty => new Order(
                disclaimerOfWarranty.Computer, disclaimerOfWarranty.Comment),
            _ => throw new ArgumentOutOfRangeException(nameof(Result)),
        };
    }
}