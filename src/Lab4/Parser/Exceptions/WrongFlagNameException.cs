using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class WrongFlagNameException : Exception
{
    public WrongFlagNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongFlagNameException(string message)
        : base(message)
    {
    }

    public WrongFlagNameException()
        : base("Wrong flag name")
    {
    }
}