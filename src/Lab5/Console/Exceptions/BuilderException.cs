namespace Console.Exceptions;

public class BuilderException : Exception
{
    public BuilderException(string message)
        : base(message)
    {
    }

    public BuilderException()
        : base("You must set all builder fields before object creation")
    {
    }

    public BuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}