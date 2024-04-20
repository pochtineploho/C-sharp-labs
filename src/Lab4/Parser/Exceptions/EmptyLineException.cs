using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class EmptyLineException : Exception
{
    public EmptyLineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyLineException(string message)
        : base(message)
    {
    }

    public EmptyLineException()
        : base("Line is empty")
    {
    }
}