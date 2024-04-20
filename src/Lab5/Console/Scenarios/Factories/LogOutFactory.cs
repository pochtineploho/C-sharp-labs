using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class LogOutFactory : ScenarioFactoryBase
{
    public LogOutFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new LogOutScenario(Service);
    }
}