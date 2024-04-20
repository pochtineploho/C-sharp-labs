using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class DeleteUserFactory : ScenarioFactoryBase
{
    public DeleteUserFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new DeleteUserScenario(Service);
    }
}