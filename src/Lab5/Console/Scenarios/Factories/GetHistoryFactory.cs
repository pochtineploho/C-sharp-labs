using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class GetHistoryFactory : ScenarioFactoryBase
{
    public GetHistoryFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new GetHistoryScenario(Service);
    }
}