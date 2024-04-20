using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class ChooseRoleFactory : ScenarioFactoryBase
{
    public ChooseRoleFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new ChooseRoleScenario(Service);
    }
}