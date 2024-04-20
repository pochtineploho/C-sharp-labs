using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;
using DataBases.Entities.Repositories;
using DataBases.Models;

namespace Core.Services.Adapters;

public class BankAccountAdapter : IBankAccountAdapter
{
    private readonly BankRepository _bankRepository;

    public BankAccountAdapter(BankRepository bankRepository)
    {
        _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
    }

    public async Task<long> GetBalance(string bankAccount)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        BankUnit unit = await _bankRepository.GetObject(bankAccount) ??
                        throw new DataBaseErrorException("Cant find user in data base");

        return unit.Budget;
    }

    public async Task<BinaryResult> Deposit(string bankAccount, long amount)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        BankUnit unit = await _bankRepository.GetObject(bankAccount) ??
                        throw new DataBaseErrorException("Cant find user in data base");

        var newUnit = new BankUnit(unit.BankAccount, unit.PinCode, unit.Budget + amount);

        OperationResult result = await _bankRepository.Update(bankAccount, newUnit);

        return result is OperationResult.Success
            ? new BinaryResult.Success(result.Message)
            : new BinaryResult.Fail(result.Message);
    }

    public async Task<BinaryResult> CashOut(string bankAccount, long amount)
    {
        return await Deposit(bankAccount, -amount);
    }

    public async Task<BinaryResult> CreateUser(string bankAccount, string pin, long money = 0)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        OperationResult result = await _bankRepository.Create(new BankUnit(bankAccount, pin, money))
                                 ?? throw new DataBaseIsNotConnectedException();

        return result is OperationResult.Success
            ? new BinaryResult.Success(result.Message)
            : new BinaryResult.Fail(result.Message);
    }

    public async Task<BinaryResult> DeleteUser(string bankAccount)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        OperationResult result = await _bankRepository.Delete(bankAccount)
                                 ?? throw new DataBaseIsNotConnectedException();

        return result is OperationResult.Success
            ? new BinaryResult.Success(result.Message)
            : new BinaryResult.Fail(result.Message);
    }

    public async Task<bool> Exists(string bankAccount)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        return await _bankRepository.GetObject(bankAccount) is not null;
    }
}