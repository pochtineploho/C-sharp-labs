namespace DataBases.Exceptions;

public class WrongPinCodeFormatException : Exception
{
    public WrongPinCodeFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongPinCodeFormatException(string message)
        : base(message)
    {
    }

    public WrongPinCodeFormatException()
        : base("Pin code must contain 4 digits")
    {
    }
}