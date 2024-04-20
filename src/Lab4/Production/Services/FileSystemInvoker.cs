using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class FileSystemInvoker
{
    private IFileSystemCommand? _command;

    public FileSystemInvoker(IFileSystemCommand? command = null)
    {
        _command = command;
    }

    public void SetCommand(IFileSystemCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public void ExecuteCommand()
    {
        if (_command is null) throw new NoCommandException();

        _command.Execute();
    }
}