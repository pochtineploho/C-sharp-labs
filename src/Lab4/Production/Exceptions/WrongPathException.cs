using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class WrongPathException : Exception
{
    public WrongPathException(string message)
        : base(message)
    {
    }

    public WrongPathException()
        : base("This path does not exist")
    {
    }

    public WrongPathException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}