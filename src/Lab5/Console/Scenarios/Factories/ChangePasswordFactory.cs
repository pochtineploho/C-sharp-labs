using Console.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class ChangePasswordFactory : ScenarioFactoryBase
{
    public ChangePasswordFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return new ChangePasswordScenario(Service);
    }
}