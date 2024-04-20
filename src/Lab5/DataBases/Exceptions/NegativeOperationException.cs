namespace DataBases.Exceptions;

public class NegativeOperationException : Exception
{
    public NegativeOperationException(string message)
        : base(message)
    { }

    public NegativeOperationException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public NegativeOperationException()
        : base("You must cash in or cash out positive amount")
    { }
}