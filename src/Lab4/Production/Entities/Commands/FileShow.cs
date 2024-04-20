using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class FileShow : IFileSystemCommand
{
    private readonly string _path;
    private readonly IOutput _output;

    public FileShow(IFileSystemOutput receiver, string path, IOutput outputMode)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _output = outputMode ?? throw new ArgumentNullException(nameof(outputMode));
    }

    public IFileSystemOutput Receiver { get; }

    public void Execute()
    {
        Receiver.FileShow(_path, _output);
    }
}