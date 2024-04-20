namespace DataBases.Exceptions;

public class ZeroOperationException : Exception
{
    public ZeroOperationException(string message)
        : base(message)
    { }

    public ZeroOperationException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public ZeroOperationException()
        : base("You can't cash in or cash out 0")
    { }
}