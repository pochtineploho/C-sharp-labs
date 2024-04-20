using Core.Models;

namespace Core.Services.Interfaces;

public interface IAdminPasswordAdapter
{
    Task<BinaryResult> ChangePassword(string username, string newPassword);

    Task<string?> GetPassword(string username);
}