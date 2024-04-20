using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class HasNotConnectedYetException : Exception
{
    public HasNotConnectedYetException(string message)
        : base(message)
    {
    }

    public HasNotConnectedYetException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public HasNotConnectedYetException()
    : base("Has mot connected to file system yet")
    {
    }
}