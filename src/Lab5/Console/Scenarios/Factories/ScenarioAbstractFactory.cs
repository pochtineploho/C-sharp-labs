using Console.Models;
using Core.Models;

namespace Console.Scenarios.Factories;

public class ScenarioAbstractFactory
{
    private readonly IFactory<IScenario> _chooseRoleFactory;
    private readonly IFactory<IScenario> _loginFactory;
    private readonly IFactory<IScenario> _chooseActionFactory;
    private readonly IFactory<IScenario> _createUserFactory;
    private readonly IFactory<IScenario> _deleteUserFactory;
    private readonly IFactory<IScenario> _changePasswordFactory;
    private readonly IFactory<IScenario> _exitFactory;
    private readonly IFactory<IScenario> _logOutFactory;
    private readonly IFactory<IScenario> _cashOutFactory;
    private readonly IFactory<IScenario> _cashInFactory;
    private readonly IFactory<IScenario> _getHistoryFactory;
    private readonly IFactory<IScenario> _getBalanceFactory;
    private readonly IFactory<IScenario> _changePinFactory;

    public ScenarioAbstractFactory(
        IFactory<IScenario> chooseRoleFactory,
        IFactory<IScenario> loginFactory,
        IFactory<IScenario> chooseActionFactory,
        IFactory<IScenario> createUserFactory,
        IFactory<IScenario> deleteUserFactory,
        IFactory<IScenario> changePasswordFactory,
        IFactory<IScenario> exitFactory,
        IFactory<IScenario>? logOutFactory,
        IFactory<IScenario>? cashOutFactory,
        IFactory<IScenario>? cashInFactory,
        IFactory<IScenario>? getHistoryFactory,
        IFactory<IScenario>? getBalanceFactory,
        IFactory<IScenario>? changePinFactory)
    {
        _chooseRoleFactory = chooseRoleFactory ?? throw new ArgumentNullException(nameof(chooseRoleFactory));
        _loginFactory = loginFactory ?? throw new ArgumentNullException(nameof(loginFactory));
        _chooseActionFactory = chooseActionFactory ?? throw new ArgumentNullException(nameof(chooseActionFactory));
        _createUserFactory = createUserFactory ?? throw new ArgumentNullException(nameof(createUserFactory));
        _deleteUserFactory = deleteUserFactory ?? throw new ArgumentNullException(nameof(deleteUserFactory));
        _changePasswordFactory = changePasswordFactory ?? throw new ArgumentNullException(nameof(changePasswordFactory));
        _exitFactory = exitFactory ?? throw new ArgumentNullException(nameof(exitFactory));
        _logOutFactory = logOutFactory ?? throw new ArgumentNullException(nameof(logOutFactory));
        _cashOutFactory = cashOutFactory ?? throw new ArgumentNullException(nameof(cashOutFactory));
        _cashInFactory = cashInFactory ?? throw new ArgumentNullException(nameof(cashInFactory));
        _getHistoryFactory = getHistoryFactory ?? throw new ArgumentNullException(nameof(getHistoryFactory));
        _getBalanceFactory = getBalanceFactory ?? throw new ArgumentNullException(nameof(getBalanceFactory));
        _changePinFactory = changePinFactory ?? throw new ArgumentNullException(nameof(changePinFactory));
    }

    public IScenario GetByName(string name)
    {
        return name switch
        {
            ScenarioNameConstants.ChooseRoleName => _chooseRoleFactory.Create(),
            ScenarioNameConstants.LoginName => _loginFactory.Create(),
            ScenarioNameConstants.ChooseActionName => _chooseActionFactory.Create(),
            ScenarioNameConstants.CreateUserName => _createUserFactory.Create(),
            ScenarioNameConstants.DeleteUserName => _deleteUserFactory.Create(),
            ScenarioNameConstants.ChangePasswordName => _changePasswordFactory.Create(),
            ScenarioNameConstants.ExitName => _exitFactory.Create(),
            ScenarioNameConstants.LogOutName => _logOutFactory.Create(),
            ScenarioNameConstants.CashOutName => _cashOutFactory.Create(),
            ScenarioNameConstants.DepositName => _cashInFactory.Create(),
            ScenarioNameConstants.GetHistoryName => _getHistoryFactory.Create(),
            ScenarioNameConstants.GetBalanceName => _getBalanceFactory.Create(),
            ScenarioNameConstants.ChangePinName => _changePinFactory.Create(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null),
        };
    }
}