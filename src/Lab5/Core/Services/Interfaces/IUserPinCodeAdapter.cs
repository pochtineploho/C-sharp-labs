using Core.Models;

namespace Core.Services.Interfaces;

public interface IUserPinCodeAdapter
{
    Task<BinaryResult> ChangePinCode(string bankAccount, string newPinCode);

    Task<string?> GetPinCode(string bankAccount);
}