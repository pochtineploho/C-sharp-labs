using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class ChangePinService : IChangePinService
{
    private readonly IUserPinCodeAdapter _adapter;

    public ChangePinService(IUserPinCodeAdapter adapter)
    {
        _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
    }

    public async Task<string> GetPin(string bankAccountNumber)
    {
        return await _adapter.GetPinCode(bankAccountNumber) ??
               throw new DataBaseErrorException("Current user is not in database");
    }

    public async Task<ChangePasswordResult> ChangePin(string bankAccountNumber, string newPin)
    {
        if (newPin == null) throw new ArgumentNullException(nameof(newPin));
        if (newPin.Length != 4 || !newPin.All(char.IsDigit))
            return new ChangePasswordResult.WrongFormat("Pin must be 4 digits");

        BinaryResult result = await _adapter.ChangePinCode(bankAccountNumber, newPin);

        return result is BinaryResult.Success
            ? new ChangePasswordResult.Success(result.Message)
            : new ChangePasswordResult.WrongFormat(result.Message);
    }
}