using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class WrongBuilderOrderException : Exception
{
    public WrongBuilderOrderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongBuilderOrderException(string message)
        : base(message)
    {
    }

    public WrongBuilderOrderException()
        : base("Builder is lack on parameters")
    {
    }
}