using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;
using DataBases.Entities.Repositories;
using DataBases.Models;

namespace Core.Services.Adapters;

public class AdminPasswordAdapter : IAdminPasswordAdapter
{
    private readonly AdminRepository _adminRepository;

    public AdminPasswordAdapter(AdminRepository adminRepository)
    {
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
    }

    public async Task<BinaryResult> ChangePassword(string username, string newPassword)
    {
        if (_adminRepository is null) throw new DataBaseIsNotConnectedException();

        AdminUnit unit = await _adminRepository.GetObject(username) ?? throw new DataBaseErrorException("Cant find user in data base");

        var newUnit = new AdminUnit(unit.Username, newPassword);

        OperationResult result = await _adminRepository.Update(username, newUnit);

        return result is OperationResult.Success
            ? new BinaryResult.Success(result.Message)
            : new BinaryResult.Fail(result.Message);
    }

    public async Task<string?> GetPassword(string username)
    {
        if (_adminRepository is null) throw new DataBaseIsNotConnectedException();

        AdminUnit? unit = await _adminRepository.GetObject(username);

        return unit?.Password;
    }
}