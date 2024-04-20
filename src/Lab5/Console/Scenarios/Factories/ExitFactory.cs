using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class ExitFactory : ScenarioFactoryBase
{
    public ExitFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new ExitScenario(Service);
    }
}