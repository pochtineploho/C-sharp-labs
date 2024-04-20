namespace DataBases.Exceptions;

public class OperationFailedException : Exception
{
    public OperationFailedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public OperationFailedException(string message)
        : base(message)
    {
    }

    public OperationFailedException()
        : base("Operation failed")
    {
    }
}