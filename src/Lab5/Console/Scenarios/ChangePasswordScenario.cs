using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ChangePasswordScenario : ScenarioBase
{
    public ChangePasswordScenario(SuperFacade services)
        : base(ScenarioNameConstants.ChangePasswordName, services)
    { }

    public override async Task<string> Run()
    {
        string currentPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your current [green]password[/]")
                .PromptStyle(Color.Grey)
                .Secret());
        while (currentPassword != await Service.GetPassword())
        {
            AnsiConsole.MarkupLine("[red]That is not your password. Try again.[/]");
            currentPassword = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter your current [green]password[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());
        }

        ChangePasswordResult result;
        do
        {
            string newPassword = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter new [green]password[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());
            result = await Service.ChangePassword(newPassword);

            AnsiConsole.MarkupLine(result is ChangePasswordResult.Success
                ? $"[green]{result.Message}[/]"
                : $"[red]{result.Message}[/]");
            System.Console.ReadKey();
        }
        while (result is not ChangePasswordResult.Success);

        return ScenarioNameConstants.ChooseActionName;
    }
}