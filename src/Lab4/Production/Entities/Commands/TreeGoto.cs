using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class TreeGoto : IFileSystemCommand
{
    private readonly string _path;

    public TreeGoto(IFileSystemOutput receiver, string path)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public IFileSystemOutput Receiver { get; }

    public void Execute()
    {
        Receiver.TreeGoto(_path);
    }
}