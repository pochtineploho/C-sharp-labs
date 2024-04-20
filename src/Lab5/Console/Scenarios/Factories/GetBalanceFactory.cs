using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class GetBalanceFactory : ScenarioFactoryBase
{
    public GetBalanceFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new GetBalanceScenario(Service);
    }
}