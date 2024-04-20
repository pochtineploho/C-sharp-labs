using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class ChangePinFactory : ScenarioFactoryBase
{
    public ChangePinFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new ChangePinScenario(Service);
    }
}