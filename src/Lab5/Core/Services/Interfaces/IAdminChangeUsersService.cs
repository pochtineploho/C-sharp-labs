using Core.Models;

namespace Core.Services.Interfaces;

public interface IAdminChangeUsersService
{
    Task<BinaryResult> CreateUser();

    Task<BinaryResult> DeleteUser(string bankAccountNumber);
}