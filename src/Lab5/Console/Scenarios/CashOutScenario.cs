using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class CashOutScenario : ScenarioBase
{
    public CashOutScenario(SuperFacade services)
        : base(ScenarioNameConstants.CashOutName, services)
    { }

    public override async Task<string> Run()
    {
        if (await Service.GetBalance() == 0)
        {
            AnsiConsole.MarkupLine("[red]You don't have any money :-([/]");
            System.Console.ReadKey();
            return ScenarioNameConstants.ChooseActionName;
        }

        BinaryResult result;
        do
        {
            int money = AnsiConsole.Ask<int>("How much [gold1]money[/] do you want to cash out?");

            result = await Service.CashOut(money);

            AnsiConsole.MarkupLine(result is BinaryResult.Success
                ? $"[green]{result.Message}[/]"
                : $"[red]{result.Message}[/]");
            System.Console.ReadKey();
        }
        while (result is not BinaryResult.Success);

        return ScenarioNameConstants.ChooseActionName;
    }
}