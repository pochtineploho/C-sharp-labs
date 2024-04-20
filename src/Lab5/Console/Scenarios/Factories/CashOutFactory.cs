using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class CashOutFactory : ScenarioFactoryBase
{
    public CashOutFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new CashOutScenario(Service);
    }
}