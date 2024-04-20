using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ChangePinScenario : ScenarioBase
{
    public ChangePinScenario(SuperFacade services)
        : base(ScenarioNameConstants.ChangePinName, services)
    { }

    public override async Task<string> Run()
    {
        string currentPin = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your current [green]PIN code[/]")
                .PromptStyle(Color.Grey)
                .Secret());
        while (currentPin != await Service.GetPin())
        {
            AnsiConsole.MarkupLine("[red]That is not your PIN code. Try again.[/]");
            currentPin = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter your current [green]PIN code[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());
        }

        ChangePasswordResult result;
        do
        {
            string newPin = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter new [green]PIN code[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());
            result = await Service.ChangePin(newPin);

            AnsiConsole.MarkupLine(result is ChangePasswordResult.Success
                ? $"[green]PIN code has changed successfully[/]"
                : $"[red]{result.Message}[/]");
            System.Console.ReadKey();
        }
        while (result is not ChangePasswordResult.Success);

        return ScenarioNameConstants.ChooseActionName;
    }
}