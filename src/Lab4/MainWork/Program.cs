using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.MainWork;

public static class Program
{
    public static void Main()
    {
        var invoker = new FileSystemInvoker();
        var parser = new ConsoleParser();
        while (true)
        {
            // Not in tests => allowed
            IReadOnlyCollection<IFileSystemCommand> commands = parser.Parse();
            foreach (IFileSystemCommand command in commands)
            {
                invoker.SetCommand(command);
                invoker.ExecuteCommand();
            }
        }
    }
}