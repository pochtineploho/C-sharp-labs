using DataBases.Exceptions;

namespace Core.Models;

public record Operation
{
    public Operation(string bankAccount, long amount, DateTime dateTime)
    {
        BankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
        Amount = amount == 0 ? throw new ZeroOperationException() : amount;
        DateTime = dateTime;
        if (bankAccount.Length != 16 || bankAccount.Any(x => !char.IsDigit(x)))
            throw new WrongBankAccountFormatException();
    }

    public string BankAccount { get; }
    public DateTime DateTime { get; }
    public long Amount { get; }
}