using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class DepositScenario : ScenarioBase
{
    public DepositScenario(SuperFacade services)
        : base(ScenarioNameConstants.DepositName, services)
    { }

    public override async Task<string> Run()
    {
        BinaryResult result;
        do
        {
            int moneyToAdd = AnsiConsole.Ask<int>("How much [gold1]money[/] do you want to deposit?");

            result = await Service.Deposit(moneyToAdd);

            AnsiConsole.MarkupLine(result is BinaryResult.Success
                ? $"[green]{result.Message}[/]"
                : $"[red]{result.Message}[/]");
            System.Console.ReadKey();
        }
        while (result is not BinaryResult.Success);

        return ScenarioNameConstants.ChooseActionName;
    }
}