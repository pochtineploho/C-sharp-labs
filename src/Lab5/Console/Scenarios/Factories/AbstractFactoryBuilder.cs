using Console.Exceptions;
using Console.Models;
using Core.Models;

namespace Console.Scenarios.Factories;

public class AbstractFactoryBuilder
{
    private IFactory<IScenario>? _chooseRoleFactory;
    private IFactory<IScenario>? _loginFactory;
    private IFactory<IScenario>? _chooseActionFactory;
    private IFactory<IScenario>? _createUserFactory;
    private IFactory<IScenario>? _deleteUserFactory;
    private IFactory<IScenario>? _changePasswordFactory;
    private IFactory<IScenario>? _exitFactory;
    private IFactory<IScenario>? _logOutFactory;
    private IFactory<IScenario>? _cashOutFactory;
    private IFactory<IScenario>? _cashInFactory;
    private IFactory<IScenario>? _getHistoryFactory;
    private IFactory<IScenario>? _getBalanceFactory;
    private IFactory<IScenario>? _changePinFactory;

    public AbstractFactoryBuilder WithChooseRoleFactory(IFactory<IScenario> chooseRoleFactory)
    {
        _chooseRoleFactory = chooseRoleFactory ?? throw new ArgumentNullException(nameof(chooseRoleFactory));
        return this;
    }

    public AbstractFactoryBuilder WithLoginFactory(IFactory<IScenario> loginFactory)
    {
        _loginFactory = loginFactory ?? throw new ArgumentNullException(nameof(loginFactory));
        return this;
    }

    public AbstractFactoryBuilder WithChooseActionFactory(IFactory<IScenario> chooseActionFactory)
    {
        _chooseActionFactory = chooseActionFactory ?? throw new ArgumentNullException(nameof(chooseActionFactory));
        return this;
    }

    public AbstractFactoryBuilder WithCreateUserFactory(IFactory<IScenario> createUserFactory)
    {
        _createUserFactory = createUserFactory ?? throw new ArgumentNullException(nameof(createUserFactory));
        return this;
    }

    public AbstractFactoryBuilder WithDeleteUserFactory(IFactory<IScenario> deleteUserFactory)
    {
        _deleteUserFactory = deleteUserFactory ?? throw new ArgumentNullException(nameof(deleteUserFactory));
        return this;
    }

    public AbstractFactoryBuilder WithChangePasswordFactory(IFactory<IScenario> changePasswordFactory)
    {
        _changePasswordFactory =
            changePasswordFactory ?? throw new ArgumentNullException(nameof(changePasswordFactory));
        return this;
    }

    public AbstractFactoryBuilder WithExitFactory(IFactory<IScenario> exitFactory)
    {
        _exitFactory = exitFactory ?? throw new ArgumentNullException(nameof(exitFactory));
        return this;
    }

    public AbstractFactoryBuilder WithLogOutFactory(IFactory<IScenario> logOutFactory)
    {
        _logOutFactory = logOutFactory ?? throw new ArgumentNullException(nameof(logOutFactory));
        return this;
    }

    public AbstractFactoryBuilder WithCashOutFactory(IFactory<IScenario> cashOutFactory)
    {
        _cashOutFactory = cashOutFactory ?? throw new ArgumentNullException(nameof(cashOutFactory));
        return this;
    }

    public AbstractFactoryBuilder WithCashInFactory(IFactory<IScenario> cashInFactory)
    {
        _cashInFactory = cashInFactory ?? throw new ArgumentNullException(nameof(cashInFactory));
        return this;
    }

    public AbstractFactoryBuilder WithGetHistoryFactory(IFactory<IScenario> getHistoryFactory)
    {
        _getHistoryFactory = getHistoryFactory ?? throw new ArgumentNullException(nameof(getHistoryFactory));
        return this;
    }

    public AbstractFactoryBuilder WithGetBalanceFactory(IFactory<IScenario> getBalanceFactory)
    {
        _getBalanceFactory = getBalanceFactory ?? throw new ArgumentNullException(nameof(getBalanceFactory));
        return this;
    }

    public AbstractFactoryBuilder WithChangePinFactory(IFactory<IScenario> changePinFactory)
    {
        _changePinFactory = changePinFactory ?? throw new ArgumentNullException(nameof(changePinFactory));
        return this;
    }

    public ScenarioAbstractFactory Build()
    {
        return new ScenarioAbstractFactory(
            _chooseRoleFactory ?? throw new BuilderException(),
            _loginFactory ?? throw new BuilderException(),
            _chooseActionFactory ?? throw new BuilderException(),
            _createUserFactory ?? throw new BuilderException(),
            _deleteUserFactory ?? throw new BuilderException(),
            _changePasswordFactory ?? throw new BuilderException(),
            _exitFactory ?? throw new BuilderException(),
            _logOutFactory ?? throw new BuilderException(),
            _cashOutFactory ?? throw new BuilderException(),
            _cashInFactory ?? throw new BuilderException(),
            _getHistoryFactory ?? throw new BuilderException(),
            _getBalanceFactory ?? throw new BuilderException(),
            _changePinFactory ?? throw new BuilderException());
    }
}