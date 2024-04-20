using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class FileDelete : IFileSystemCommand
{
    private readonly string _path;

    public FileDelete(IFileSystemOutput receiver, string path)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public IFileSystemOutput Receiver { get; }
    public void Execute()
    {
        Receiver.FileDelete(_path);
    }
}