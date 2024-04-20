using Core.Models;

namespace Core.Services.Interfaces;

public interface IChangePasswordService
{
    Task<string> GetPassword(string username);
    Task<ChangePasswordResult> ChangePassword(string username, string newPassword);
}