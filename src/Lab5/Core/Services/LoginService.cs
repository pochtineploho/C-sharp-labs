using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class LoginService : ILoginService
{
    private readonly IAdminPasswordAdapter _adminPasswordAdapter;
    private readonly IUserPinCodeAdapter _userPinCodeAdapter;

    public LoginService(IAdminPasswordAdapter adminPasswordAdapter, IUserPinCodeAdapter userPinCodeAdapter)
    {
        _adminPasswordAdapter = adminPasswordAdapter ?? throw new ArgumentNullException(nameof(adminPasswordAdapter));
        _userPinCodeAdapter = userPinCodeAdapter ?? throw new ArgumentNullException(nameof(userPinCodeAdapter));
    }

    public async Task<LoginResult> LoginAdmin(string username, string password)
    {
        string? currentPassword = await _adminPasswordAdapter.GetPassword(username);

        if (currentPassword is null) return new LoginResult.NotFound("There is no admin with this username");
        if (currentPassword != password) return new LoginResult.WrongPassword("Wrong password");

        return new LoginResult.Success("Welcome!");
    }

    public async Task<LoginResult> LoginUser(string bankAccountNumber, string pinCode)
    {
        string? currentPin = await _userPinCodeAdapter.GetPinCode(bankAccountNumber);

        if (currentPin is null) return new LoginResult.NotFound("There is no bank account with this number");
        if (currentPin != pinCode) return new LoginResult.WrongPassword("Wrong password");

        return new LoginResult.Success("Welcome!");
    }
}