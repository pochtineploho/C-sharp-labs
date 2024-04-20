using Console.Entities;
using Spectre.Console;

namespace Console;

public static class Program
{
    public static async Task Main()
    {
        const string connectionString = "Server=localhost;Port=5432;User Id=pochtineploho;Password=12345678;Database=bank;";

        var runner = new ScenarioRunner(connectionString);

        await runner.Run();

        AnsiConsole.Console.MarkupLine("[green]Good bye![/]");
    }
}