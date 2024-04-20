using Console.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ChooseActionScenario : ScenarioBase
{
    private readonly IEnumerable<string> _possibleScenarios;

    public ChooseActionScenario(SuperFacade services, IEnumerable<string> possibleScenarios)
        : base(ScenarioNameConstants.ChooseActionName, services)
    {
        _possibleScenarios = possibleScenarios;
    }

    public override Task<string> Run()
    {
        SelectionPrompt<string> selector = new SelectionPrompt<string>()
            .Title("Select action")
            .AddChoices(_possibleScenarios);

        return Task.FromResult(AnsiConsole.Prompt(selector));
    }
}