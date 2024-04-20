using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;
using DataBases.Entities.Repositories;
using DataBases.Models;

namespace Core.Services.Adapters;

public class UserPinCodeAdapter : IUserPinCodeAdapter
{
    private readonly BankRepository _bankRepository;

    public UserPinCodeAdapter(BankRepository bankRepository)
    {
        _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
    }

    public async Task<BinaryResult> ChangePinCode(string bankAccount, string newPinCode)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        BankUnit unit = await _bankRepository.GetObject(bankAccount) ??
                        throw new DataBaseErrorException("Cant find user in data base");

        var newUnit = new BankUnit(unit.BankAccount, newPinCode, unit.Budget);

        OperationResult result = await _bankRepository.Update(bankAccount, newUnit);

        return result is OperationResult.Success ?
            new BinaryResult.Success(result.Message) :
            new BinaryResult.Fail(result.Message);
    }

    public async Task<string?> GetPinCode(string bankAccount)
    {
        if (_bankRepository is null) throw new DataBaseIsNotConnectedException();

        BankUnit? unit = await _bankRepository.GetObject(bankAccount);

        return unit?.PinCode;
    }
}