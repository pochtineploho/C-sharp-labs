using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class IncompatibleComponentsException : Exception
{
    public IncompatibleComponentsException(string message)
        : base(message)
    { }

    public IncompatibleComponentsException()
    { }

    public IncompatibleComponentsException(string message, Exception innerException)
        : base(message, innerException)
    { }
}