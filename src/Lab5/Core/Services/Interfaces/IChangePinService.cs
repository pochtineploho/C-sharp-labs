using Core.Models;

namespace Core.Services.Interfaces;

public interface IChangePinService
{
    Task<ChangePasswordResult> ChangePin(string bankAccountNumber, string newPin);

    Task<string> GetPin(string bankAccountNumber);
}