using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class ComputerValidator : IComputerValidator
{
    private readonly List<IComputerValidator> _validators = new List<IComputerValidator>()
    {
        new MotherboardValidator(),
        new CpuValidator(),
        new CpuCoolingFacilityValidator(),
        new GpuValidator(),
        new MemoryValidator(),
        new PowerSupplyValidator(),
        new RamValidator(),
        new WifiAdapterValidator(),
    };

    public ComputerValidationResult Validate(Computer computer)
    {
        foreach (ComputerValidationResult? result in _validators.Select(validator => validator.Validate(computer))
                     .Where(result => result is not ComputerValidationResult.Success))
        {
            return result;
        }

        return new ComputerValidationResult.Success(computer);
    }
}