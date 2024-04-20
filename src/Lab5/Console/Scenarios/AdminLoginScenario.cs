using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class AdminLoginScenario : ScenarioBase
{
    private const int MaxTriesBeforeExit = 3;

    public AdminLoginScenario(SuperFacade services)
        : base(ScenarioNameConstants.LoginName, services)
    { }

    public override async Task<string> Run()
    {
        AnsiConsole.Clear();
        string username = AnsiConsole.Ask<string>("Enter your [green]username[/]");

        LoginResult result = new LoginResult.WrongPassword(username);
        int currentTry = 0;

        while (result is LoginResult.WrongPassword && currentTry++ < MaxTriesBeforeExit)
        {
            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]password[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());

            result = await Service.LoginAdmin(username, password);

            AnsiConsole.MarkupLine(result is LoginResult.Success
                ? $"[green]{result.Message}[/]"
                : $"[red]{result.Message}[/]");
            System.Console.ReadKey();
        }

        return result switch
        {
            LoginResult.NotFound => ScenarioNameConstants.LoginName,
            LoginResult.Success => ScenarioNameConstants.ChooseActionName,
            LoginResult.WrongPassword => string.Empty,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}