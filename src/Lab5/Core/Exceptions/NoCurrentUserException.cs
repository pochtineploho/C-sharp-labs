namespace Core.Exceptions;

public class NoCurrentUserException : Exception
{
    public NoCurrentUserException(string message)
        : base(message)
    {
    }

    public NoCurrentUserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NoCurrentUserException()
        : base("There is no current user")
    {
    }
}