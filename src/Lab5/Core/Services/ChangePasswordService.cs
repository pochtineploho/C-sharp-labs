using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class ChangePasswordService : IChangePasswordService
{
    private readonly IAdminPasswordAdapter _adapter;

    public ChangePasswordService(IAdminPasswordAdapter adminPasswordAdapter)
    {
        _adapter = adminPasswordAdapter ?? throw new ArgumentNullException(nameof(adminPasswordAdapter));
    }

    public async Task<string> GetPassword(string username)
    {
        return await _adapter.GetPassword(username) ??
               throw new DataBaseErrorException("Current admin is not in database");
    }

    public async Task<ChangePasswordResult> ChangePassword(string username, string newPassword)
    {
        BinaryResult result =
            await _adapter.ChangePassword(username, newPassword);

        return result is BinaryResult.Success
            ? new ChangePasswordResult.Success("Password has changed successfully")
            : new ChangePasswordResult.WrongFormat(result.Message);
    }
}