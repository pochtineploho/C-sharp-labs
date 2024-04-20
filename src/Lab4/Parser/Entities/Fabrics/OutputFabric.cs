using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.Fabrics;

public class OutputFabric : FabricBase<IOutput>
{
    public OutputFabric()
        : base(new[]
        {
            new FabricType<IOutput>("console", new ConsoleOutput()),
        })
    { }
}