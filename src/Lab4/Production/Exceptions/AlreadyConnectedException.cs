using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;

public class AlreadyConnectedException : Exception
{
    public AlreadyConnectedException(string message)
        : base(message)
    {
    }

    public AlreadyConnectedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AlreadyConnectedException()
    : base("Already connected to a file system")
    {
    }
}