using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class RoleService : IRoleService
{
    public IEnumerable<Role> GetAllRoles()
    {
        return Enum.GetValues(typeof(Role)).Cast<Role>().AsEnumerable();
    }
}