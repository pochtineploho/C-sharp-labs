namespace Console.Models;

public interface IScenario
{
    string Name { get; }

    Task<string> Run();
}