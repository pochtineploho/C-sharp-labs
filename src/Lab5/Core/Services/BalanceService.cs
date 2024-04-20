using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class BalanceService : IBalanceService
{
    private readonly IBankAccountAdapter _bankAccountAdapter;
    private readonly IOperationsHistoryAdapter _historyAdapter;

    public BalanceService(IBankAccountAdapter bankAccountAdapter, IOperationsHistoryAdapter historyAdapter)
    {
        _bankAccountAdapter = bankAccountAdapter ?? throw new ArgumentNullException(nameof(bankAccountAdapter));
        _historyAdapter = historyAdapter ?? throw new ArgumentNullException(nameof(historyAdapter));
    }

    public async Task<BinaryResult> CashOut(string bankAccountNumber, long amount)
    {
        if (amount <= 0) return new BinaryResult.Fail("You can't cash out negative amount");
        if (amount > await GetBalance(bankAccountNumber)) return new BinaryResult.Fail("Not enough money");

        BinaryResult result = await _bankAccountAdapter.CashOut(bankAccountNumber, amount);

        if (result is BinaryResult.Success)
            await _historyAdapter.AddOperation(bankAccountNumber, DateTime.Now, -amount);

        return result;
    }

    public async Task<BinaryResult> Deposit(string bankAccountNumber, long amount)
    {
        if (amount <= 0) return new BinaryResult.Fail("You can't deposit negative amount");

        BinaryResult result = await _bankAccountAdapter.Deposit(bankAccountNumber, amount);

        if (result is BinaryResult.Success)
            await _historyAdapter.AddOperation(bankAccountNumber, DateTime.Now, amount);

        return result;
    }

    public async Task<long> GetBalance(string bankAccountNumber)
    {
        return await _bankAccountAdapter.GetBalance(bankAccountNumber);
    }
}