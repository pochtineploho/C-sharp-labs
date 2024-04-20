using Console.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ExitScenario : ScenarioBase
{
    public ExitScenario(SuperFacade services)
        : base(ScenarioNameConstants.ExitName, services)
    { }

    public override Task<string> Run()
    {
        if (!AnsiConsole.Confirm("Are you sure?"))
        {
            return Task.FromResult(ScenarioNameConstants.ChooseActionName);
        }

        Service.LogOut();

        return Task.FromResult(string.Empty);
    }
}