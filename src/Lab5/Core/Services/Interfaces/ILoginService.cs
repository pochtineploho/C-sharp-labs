using Core.Models;

namespace Core.Services.Interfaces;

public interface ILoginService
{
    Task<LoginResult> LoginAdmin(string username, string password);

    Task<LoginResult> LoginUser(string bankAccountNumber, string pinCode);
}