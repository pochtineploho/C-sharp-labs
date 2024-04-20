using System.Globalization;
using Console.Models;
using Core.Models;
using Core.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class GetHistoryScenario : ScenarioBase
{
    public GetHistoryScenario(SuperFacade services)
        : base(ScenarioNameConstants.GetHistoryName, services)
    { }

    public override async Task<string> Run()
    {
        IEnumerable<Operation> history = await Service.GetHistory();

        var table = new Table();

        table.AddColumn(new TableColumn("Time").Centered());
        table.AddColumn(new TableColumn("Operation").Centered());

        foreach (Operation operation in history)
        {
            string color = operation.Amount > 0 ? "[green]" : "[red]";
            table.AddRow(
                operation.DateTime.ToString(new DateTimeFormatInfo()),
                $"{color}{operation.Amount.ToString(new DateTimeFormatInfo())}[/]");
        }

        AnsiConsole.Write(table);
        System.Console.ReadKey();

        return ScenarioNameConstants.ChooseActionName;
    }
}