using Core.Services;

namespace Console.Models;

public abstract class ScenarioBase : IScenario
{
    protected ScenarioBase(string name, SuperFacade services)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Service = services ?? throw new ArgumentNullException(nameof(services));
    }

    public string Name { get; }
    protected SuperFacade Service { get; }
    public abstract Task<string> Run();
}