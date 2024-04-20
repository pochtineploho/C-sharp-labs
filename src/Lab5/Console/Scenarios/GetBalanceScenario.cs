using Console.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class GetBalanceScenario : ScenarioBase
{
    public GetBalanceScenario(SuperFacade services)
        : base(ScenarioNameConstants.GetBalanceName, services)
    { }

    public override async Task<string> Run()
    {
        long balance = await Service.GetBalance();

        AnsiConsole.MarkupLine($"Your balance is [gold1]{balance}[/]");
        System.Console.ReadKey();

        return ScenarioNameConstants.ChooseActionName;
    }
}