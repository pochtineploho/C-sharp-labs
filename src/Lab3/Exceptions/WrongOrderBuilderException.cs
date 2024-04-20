using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class WrongOrderBuilderException : ArgumentNullException
{
    public WrongOrderBuilderException(string message)
        : base(message)
    {
    }

    public WrongOrderBuilderException()
    : base($"Wrong order in builder")
    {
    }

    public WrongOrderBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}