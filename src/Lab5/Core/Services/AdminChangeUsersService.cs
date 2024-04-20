#pragma warning disable CA5394
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class AdminChangeUsersService : IAdminChangeUsersService
{
    private readonly IBankAccountAdapter _bankAccountAdapter;

    public AdminChangeUsersService(IBankAccountAdapter bankAccountAdapter)
    {
        _bankAccountAdapter = bankAccountAdapter ?? throw new ArgumentNullException(nameof(bankAccountAdapter));
    }

    public async Task<BinaryResult> CreateUser()
    {
        var rand = new Random();
        string accountNumber = "6969" + rand.NextInt64(100000000000, 999999999999);
        while (await _bankAccountAdapter.Exists(accountNumber))
        {
            accountNumber = "6969" + rand.NextInt64(100000000000, 999999999999);
        }

        return await _bankAccountAdapter.CreateUser(accountNumber, "6969");
    }

    public async Task<BinaryResult> DeleteUser(string bankAccountNumber)
    {
        return await _bankAccountAdapter.DeleteUser(bankAccountNumber);
    }
}