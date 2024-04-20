using Console.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class LogOutScenario : ScenarioBase
{
    public LogOutScenario(SuperFacade services)
        : base(ScenarioNameConstants.LogOutName, services)
    { }

    public override Task<string> Run()
    {
        if (!AnsiConsole.Confirm("Are you sure?"))
        {
            return Task.FromResult(ScenarioNameConstants.ChooseActionName);
        }

        Service.LogOut();

        return Task.FromResult(ScenarioNameConstants.ChooseRoleName);
    }
}