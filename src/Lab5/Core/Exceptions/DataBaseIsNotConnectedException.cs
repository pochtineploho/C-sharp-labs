namespace Core.Exceptions;

public class DataBaseIsNotConnectedException : Exception
{
    public DataBaseIsNotConnectedException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public DataBaseIsNotConnectedException(string message)
        : base(message)
    { }

    public DataBaseIsNotConnectedException()
        : base("Data base has not been connected yet")
    { }
}