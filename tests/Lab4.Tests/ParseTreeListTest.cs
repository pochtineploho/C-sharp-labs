using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseTreeListTest
{
    [Theory]
    [MemberData(nameof(Lab4TestDataGenerator.TreeListData), MemberType = typeof(Lab4TestDataGenerator))]
    public void TryToParse(string connectPath, int depth)
    {
        var parser = new StringParser($"connect {connectPath} -m test tree list -d {depth}");
        IReadOnlyCollection<IFileSystemCommand> commands = parser.Parse();
        var invoker = new FileSystemInvoker();
        IFileSystem? fileSystem = null;
        foreach (IFileSystemCommand command in commands)
        {
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
            fileSystem = command.Receiver?.GetReceiverFileSystem();
        }

        Assert.IsType<TestFileSystem>(fileSystem);
        if (fileSystem is not TestFileSystem testFileSystem) return;
        Assert.IsType<CommandResult.TreeList>(testFileSystem.Result);
        if (testFileSystem.Result is not CommandResult.TreeList result) return;
        Assert.Equal(depth, result.Depth);
    }
}