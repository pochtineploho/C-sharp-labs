using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseFileShowTest
{
    [Theory]
    [MemberData(nameof(Lab4TestDataGenerator.FileDeleteShowData), MemberType = typeof(Lab4TestDataGenerator))]
    public void TryToParse(string connectPath, string filePath)
    {
        var parser = new StringParser($"connect {connectPath} -m test file show {filePath} -m console");
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
        Assert.IsType<CommandResult.FileShow>(testFileSystem.Result);
        if (testFileSystem.Result is not CommandResult.FileShow result) return;
        Assert.Equal(filePath, result.Path);
    }
}