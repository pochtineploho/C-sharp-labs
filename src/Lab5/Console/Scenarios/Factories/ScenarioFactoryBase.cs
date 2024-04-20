using Console.Models;
using Core.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public abstract class ScenarioFactoryBase : IFactory<IScenario>
{
    protected ScenarioFactoryBase(SuperFacade service)
    {
        Service = service ?? throw new ArgumentNullException(nameof(service));
    }

    protected SuperFacade Service { get; set; }
    public abstract IScenario Create();
}