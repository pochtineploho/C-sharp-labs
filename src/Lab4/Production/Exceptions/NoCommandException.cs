using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class NoCommandException : Exception
{
    public NoCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NoCommandException(string message)
        : base(message)
    {
    }

    public NoCommandException()
        : base("You have not chosen the command in invoker")
    {
    }
}