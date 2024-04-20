namespace Core.Exceptions;

public class DataBaseErrorException : Exception
{
    public DataBaseErrorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DataBaseErrorException(string message)
        : base(message)
    {
    }

    public DataBaseErrorException()
    {
    }
}