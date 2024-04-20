using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class AlreadyExistsException : ArgumentOutOfRangeException
{
    public AlreadyExistsException(string message)
        : base(message)
    {
    }

    public AlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AlreadyExistsException()
    : base($"Object with the same name already in collection")
    {
    }
}