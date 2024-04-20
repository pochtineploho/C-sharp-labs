using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class CreateUserScenario : ScenarioBase
{
    public CreateUserScenario(SuperFacade services)
        : base(ScenarioNameConstants.CreateUserName, services)
    { }

    public override async Task<string> Run()
    {
        if (!AnsiConsole.Confirm("Are you sure?"))
        {
            return await Task.FromResult(ScenarioNameConstants.ChooseActionName);
        }

        BinaryResult result;
        do
        {
            result = await Service.CreateUser();
            if (result is not BinaryResult.Success) AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
        }
        while (result is not BinaryResult.Success);

        AnsiConsole.MarkupLine($"[green]{result.Message}[/]");
        System.Console.ReadKey();

        return await Task.FromResult(ScenarioNameConstants.ChooseActionName);
    }
}