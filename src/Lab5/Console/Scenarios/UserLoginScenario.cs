using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class UserLoginScenario : ScenarioBase
{
    public UserLoginScenario(SuperFacade services)
        : base(ScenarioNameConstants.LoginName, services)
    { }

    public override async Task<string> Run()
    {
        AnsiConsole.Clear();
        string bankAccountNumber = AnsiConsole.Ask<string>("Enter your [green]bank account number[/]");

        LoginResult result = new LoginResult.WrongPassword(bankAccountNumber);

        while (result is LoginResult.WrongPassword)
        {
            string pinCode = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]PIN code[/]")
                    .PromptStyle(Color.Grey)
                    .Secret());

            result = await Service.LoginUser(bankAccountNumber, pinCode);

            AnsiConsole.MarkupLine(result is LoginResult.Success
                ? $"[green]{result.Message}[/]"
                : $"[red]{result.Message}[/]");

            System.Console.ReadKey();
        }

        return result is LoginResult.NotFound
            ? ScenarioNameConstants.LoginName
            : ScenarioNameConstants.ChooseActionName;
    }
}