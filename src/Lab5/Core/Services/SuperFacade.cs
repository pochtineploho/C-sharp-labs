#pragma warning disable CA1024
using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class SuperFacade
{
    private readonly IAdminChangeUsersService _adminChangeUsersService;
    private readonly IBalanceService _balanceService;
    private readonly IChangePasswordService _changePasswordService;
    private readonly IChangePinService _changePinService;
    private readonly IRoleService _roleService;
    private readonly IGetHistoryService _getHistoryService;
    private readonly ILoginService _loginService;

    private AbstractUser? _currentUser;

    public SuperFacade(
        IAdminChangeUsersService adminChangeUsersService,
        IBalanceService balanceService,
        IChangePinService changePinService,
        IChangePasswordService changePasswordService,
        IRoleService roleService,
        IGetHistoryService getHistoryService,
        ILoginService loginService)
    {
        _adminChangeUsersService = adminChangeUsersService;
        _balanceService = balanceService;
        _changePasswordService = changePasswordService;
        _roleService = roleService;
        _getHistoryService = getHistoryService;
        _loginService = loginService;
        _changePinService = changePinService;

        _currentUser = null;
    }

    public async Task<BinaryResult> CreateUser()
    {
        return await _adminChangeUsersService.CreateUser();
    }

    public async Task<BinaryResult> DeleteUser(string bankAccountNumber)
    {
        return await _adminChangeUsersService.DeleteUser(bankAccountNumber);
    }

    public void SetCurrentUserRole(Role role)
    {
        _currentUser = role switch
        {
            Role.Admin => new AbstractUser.Admin(),
            Role.User => new AbstractUser.User(),
            _ => _currentUser,
        };
    }

    public Role? GetCurrentUserRole()
    {
        return _currentUser switch
        {
            AbstractUser.Admin => Role.Admin,
            AbstractUser.User => Role.User,
            _ => null,
        };
    }

    public IEnumerable<Role> GetAllRoles()
    {
        return _roleService.GetAllRoles();
    }

    public async Task<LoginResult> LoginUser(string bankAccountNumber, string pinCode)
    {
        if (_currentUser is null) throw new NoCurrentUserException();

        LoginResult result = await _loginService.LoginUser(bankAccountNumber, pinCode);
        if (result is LoginResult.Success) _currentUser.Id = bankAccountNumber;

        return result;
    }

    public async Task<LoginResult> LoginAdmin(string username, string password)
    {
        if (_currentUser is null) throw new NoCurrentUserException();

        LoginResult result = await _loginService.LoginAdmin(username, password);
        if (result is LoginResult.Success) _currentUser.Id = username;

        return result;
    }

    public void LogOut()
    {
        _currentUser = null;
    }

    public async Task<IEnumerable<Operation>> GetHistory()
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _getHistoryService.GetHistory(_currentUser.Id);
    }

    public async Task<ChangePasswordResult> ChangePin(string newPin)
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _changePinService.ChangePin(_currentUser.Id, newPin);
    }

    public async Task<string> GetPin()
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _changePinService.GetPin(_currentUser.Id);
    }

    public async Task<ChangePasswordResult> ChangePassword(string newPassword)
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _changePasswordService.ChangePassword(_currentUser.Id, newPassword);
    }

    public async Task<string> GetPassword()
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _changePasswordService.GetPassword(_currentUser.Id);
    }

    public async Task<BinaryResult> CashOut(long amount)
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _balanceService.CashOut(_currentUser.Id, amount);
    }

    public async Task<BinaryResult> Deposit(long amount)
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _balanceService.Deposit(_currentUser.Id, amount);
    }

    public async Task<long> GetBalance()
    {
        if (_currentUser is null) throw new NoCurrentUserException();
        if (_currentUser.Id is null) throw new NoCurrentUserException();

        return await _balanceService.GetBalance(_currentUser.Id);
    }
}