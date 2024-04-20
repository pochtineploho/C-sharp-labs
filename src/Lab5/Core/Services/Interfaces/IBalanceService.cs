using Core.Models;

namespace Core.Services.Interfaces;

public interface IBalanceService
{
    Task<BinaryResult> CashOut(string bankAccountNumber, long amount);

    Task<BinaryResult> Deposit(string bankAccountNumber, long amount);

    Task<long> GetBalance(string bankAccountNumber);
}