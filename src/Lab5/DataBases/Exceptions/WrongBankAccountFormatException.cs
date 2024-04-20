namespace DataBases.Exceptions;

public class WrongBankAccountFormatException : Exception
{
    public WrongBankAccountFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongBankAccountFormatException(string message)
        : base(message)
    {
    }

    public WrongBankAccountFormatException()
    : base("Bank account number must have type long")
    {
    }
}