using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class DoesntExistException : ArgumentOutOfRangeException
{
    public DoesntExistException(string message)
        : base(message)
    {
    }

    public DoesntExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DoesntExistException()
    : base($"This message does not exist")
    {
    }
}