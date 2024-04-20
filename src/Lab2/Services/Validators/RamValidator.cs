using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class RamValidator : IComputerValidator
{
    public ComputerValidationResult Validate(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));

        if (computer.RamSticks.Count > computer.Motherboard.RamSlots)
            return new ComputerValidationResult.IncompatibleComponents(computer, "Not enough RAM slots in motherboard");
        foreach (Ram ram in computer.RamSticks)
        {
            if (ram.XmpDocps.Count > 0 && !computer.Motherboard.XmpCompatibility)
            {
                return new ComputerValidationResult.IncompatibleComponents(
                    computer,
                    "Motherboard doesn't support XMP and DOCP");
            }

            if (ram.DdrStandard != computer.Motherboard.DdrStandard)
            {
                return new ComputerValidationResult.IncompatibleComponents(
                    computer,
                    "RAM doesn't match motherboard's DDR standard");
            }

            if (ram.XmpDocps.Any(xmp => xmp.Frequency > computer.Cpu.MaxMemoryFrequency))
            {
                return new ComputerValidationResult.IncompatibleComponents(
                    computer,
                    "XMP profile doesn't match CPU frequency");
            }

            if (computer.Motherboard.MemoryCompatibility.All(chipset =>
                    ram.XmpDocps.Any(jedec => jedec.Frequency > chipset.Frequency)))
            {
                return new ComputerValidationResult.Warning(
                    computer,
                    "RAM is too fast for the motherboard, performance will be cut");
            }
        }

        return new ComputerValidationResult.Success(computer);
    }
}