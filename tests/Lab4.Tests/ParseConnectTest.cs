using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseConnectTest
{
    [Theory]
    [MemberData(nameof(Lab4TestDataGenerator.ConnectPath), MemberType = typeof(Lab4TestDataGenerator))]
    public void TryToParse(string path)
    {
        IFileSystem? fileSystem = null;
        Parser.Models.ParserBase parser = new StringParser($"connect {path} -m test");
        IReadOnlyCollection<IFileSystemCommand> commands = parser.Parse();
        var invoker = new FileSystemInvoker();
        foreach (IFileSystemCommand command in commands)
        {
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
            fileSystem = command.Receiver?.GetReceiverFileSystem();
        }

        Assert.IsType<TestFileSystem>(fileSystem);
        if (fileSystem is not TestFileSystem testFileSystem) return;
        Assert.IsType<CommandResult.Connect>(testFileSystem.Result);
        if (testFileSystem.Result is CommandResult.Connect result)
        {
            Assert.Equal(path, result.Path);
        }
    }
}