using Core.Models;

namespace Core.Services.Interfaces;

public interface IBankAccountAdapter
{
    Task<long> GetBalance(string bankAccount);

    Task<BinaryResult> Deposit(string bankAccount, long amount);

    Task<BinaryResult> CashOut(string bankAccount, long amount);

    Task<BinaryResult> CreateUser(string bankAccount, string pin, long money = 0);

    Task<BinaryResult> DeleteUser(string bankAccount);

    Task<bool> Exists(string bankAccount);
}