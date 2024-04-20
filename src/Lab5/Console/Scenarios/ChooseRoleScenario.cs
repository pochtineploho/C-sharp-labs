using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ChooseRoleScenario : ScenarioBase
{
    public ChooseRoleScenario(SuperFacade services)
        : base(ScenarioNameConstants.ChooseRoleName, services)
    {
    }

    public override Task<string> Run()
    {
        IEnumerable<Role> choices = Service.GetAllRoles();
        SelectionPrompt<Role> selector = new SelectionPrompt<Role>()
            .Title("Select [green]role[/]")
            .AddChoices(choices)
            .UseConverter(x => x.ToString());
        Role role = AnsiConsole.Prompt(selector);

        Service.SetCurrentUserRole(role);

        return Task.FromResult(!AnsiConsole.Confirm($"You selected [green]{role}[/]. Are ypu sure?")
            ? ScenarioNameConstants.ChooseRoleName
            : ScenarioNameConstants.LoginName);
    }
}