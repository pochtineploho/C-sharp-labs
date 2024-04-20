using DataBases.Exceptions;

namespace DataBases.Models;

public record BankUnit
{
    public BankUnit(string bankAccount, string pinCode, long budget)
    {
        if (budget < 0) throw new ArgumentOutOfRangeException(nameof(budget));
        BankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
        PinCode = pinCode ?? throw new ArgumentNullException(nameof(pinCode));
        Budget = budget;
        if (bankAccount.Length != 16 || bankAccount.Any(x => !char.IsDigit(x)))
            throw new WrongBankAccountFormatException();
        if (pinCode.Length != 4 || pinCode.Any(x => !char.IsDigit(x)))
            throw new WrongPinCodeFormatException();
    }

    public string BankAccount { get; }
    public string PinCode { get; }
    public long Budget { get; }
}