#pragma warning disable CA1034

using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record ComputerValidationResult
{
    public record Success(Computer Computer) : ComputerValidationResult;

    public record Warning(Computer Computer, string Comment) : ComputerValidationResult;

    public record DisclaimerOfWarranty(Computer Computer, string Comment) : ComputerValidationResult;

    public record IncompatibleComponents(Computer Computer, string Comment) : ComputerValidationResult;
}