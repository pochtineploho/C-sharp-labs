using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class FileRename : IFileSystemCommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRename(IFileSystemOutput receiver, string path, string name)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public IFileSystemOutput Receiver { get; }

    public void Execute()
    {
        Receiver.FileRename(_path, _name);
    }
}