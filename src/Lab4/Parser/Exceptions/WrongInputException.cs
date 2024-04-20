using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class WrongInputException : Exception
{
    public WrongInputException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongInputException(string message)
        : base(message)
    {
    }

    public WrongInputException()
        : base("Error in input")
    {
    }
}