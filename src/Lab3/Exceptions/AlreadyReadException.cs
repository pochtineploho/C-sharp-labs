using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class AlreadyReadException : ArgumentOutOfRangeException
{
    public AlreadyReadException(string message)
        : base(message)
    {
    }

    public AlreadyReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AlreadyReadException()
    : base("Message has already been read")
    {
    }
}