using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class SameFileNameException : Exception
{
    public SameFileNameException(string message)
        : base(message)
    {
    }

    public SameFileNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public SameFileNameException()
    : base("File with the same name already exists")
    {
    }
}