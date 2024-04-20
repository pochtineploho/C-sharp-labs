using Console.Models;
using Console.Scenarios.Factories;
using Spectre.Console;

namespace Console.Entities;

public class ScenarioRunner : IScenarioRunner
{
    private readonly string _connectionString;

    public ScenarioRunner(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public async Task Run()
    {
        string scenario = ScenarioNameConstants.ChooseRoleName;
        ScenarioAbstractFactory factory = new AbstractFactoryDirector().BuildDefault(_connectionString);

        while (!string.IsNullOrEmpty(scenario))
        {
            scenario = await factory.GetByName(scenario).Run();
            AnsiConsole.Clear();
        }
    }
}