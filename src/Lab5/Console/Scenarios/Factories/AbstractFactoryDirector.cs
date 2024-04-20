using Console.Models;
using Core.Services;
using Core.Services.Adapters;
using DataBases.Entities.Repositories;

namespace Console.Scenarios.Factories;

public class AbstractFactoryDirector
{
    private readonly AbstractFactoryBuilder _builder = new AbstractFactoryBuilder();

    public ScenarioAbstractFactory BuildDefault(string connectionString)
    {
        var bankRepository = new BankRepository(connectionString);
        var adminRepository = new AdminRepository(connectionString);
        var historyRepository = new HistoryRepository(connectionString);
        var service = new SuperFacade(
            new AdminChangeUsersService(new BankAccountAdapter(bankRepository)),
            new BalanceService(new BankAccountAdapter(bankRepository), new OperationHistoryAdapter(historyRepository)),
            new ChangePinService(new UserPinCodeAdapter(bankRepository)),
            new ChangePasswordService(new AdminPasswordAdapter(adminRepository)),
            new RoleService(),
            new GetHistoryService(new OperationHistoryAdapter(historyRepository)),
            new LoginService(new AdminPasswordAdapter(adminRepository), new UserPinCodeAdapter(bankRepository)));

        return _builder
            .WithCashInFactory(new CashInFactory(service))
            .WithCashOutFactory(new CashOutFactory(service))
            .WithChangePasswordFactory(new ChangePasswordFactory(service))
            .WithChangePinFactory(new ChangePinFactory(service))
            .WithChooseRoleFactory(new ChooseRoleFactory(service))
            .WithCreateUserFactory(new CreateUserFactory(service))
            .WithDeleteUserFactory(new DeleteUserFactory(service))
            .WithExitFactory(new ExitFactory(service))
            .WithGetBalanceFactory(new GetBalanceFactory(service))
            .WithGetHistoryFactory(new GetHistoryFactory(service))
            .WithLoginFactory(new LoginFactory(service))
            .WithLogOutFactory(new LogOutFactory(service))
            .WithChooseActionFactory(new ChooseActionFactory(
                service,
                new[]
                {
                    ScenarioNameConstants.GetBalanceName,
                    ScenarioNameConstants.CashOutName,
                    ScenarioNameConstants.DepositName,
                    ScenarioNameConstants.GetHistoryName,
                    ScenarioNameConstants.ChangePinName,
                    ScenarioNameConstants.LogOutName,
                    ScenarioNameConstants.ExitName,
                },
                new[]
                {
                    ScenarioNameConstants.CreateUserName,
                    ScenarioNameConstants.DeleteUserName,
                    ScenarioNameConstants.ChangePasswordName,
                    ScenarioNameConstants.LogOutName,
                    ScenarioNameConstants.ExitName,
                }))
            .Build();
    }
}