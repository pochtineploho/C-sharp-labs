using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class CreateUserFactory : ScenarioFactoryBase
{
    public CreateUserFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new CreateUserScenario(Service);
    }
}