using Core.Models;

namespace Core.Services.Interfaces;

public interface IRoleService
{
    IEnumerable<Role> GetAllRoles();
}