using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class CashInFactory : ScenarioFactoryBase
{
    public CashInFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new DepositScenario(Service);
    }
}