using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class DeleteUserScenario : ScenarioBase
{
    public DeleteUserScenario(SuperFacade services)
        : base(ScenarioNameConstants.DeleteUserName, services)
    { }

    public override async Task<string> Run()
    {
        BinaryResult result;
        do
        {
            string bankAccount = AnsiConsole.Ask<string>("Which bank account number?");
            if (!AnsiConsole.Confirm("Are you sure?"))
            {
                return ScenarioNameConstants.ChooseActionName;
            }

            result = await Service.DeleteUser(bankAccount);
            if (result is not BinaryResult.Success) AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
        }
        while (result is not BinaryResult.Success);

        AnsiConsole.MarkupLine($"[green]{result.Message}[/]");
        System.Console.ReadKey();

        return ScenarioNameConstants.ChooseActionName;
    }
}