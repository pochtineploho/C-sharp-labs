using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class TreeList : IFileSystemCommand
{
    private readonly int _depth;

    public TreeList(IFileSystemOutput receiver, int depth = 1)
    {
        if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth));
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _depth = depth;
    }

    public IFileSystemOutput Receiver { get; }

    public void Execute()
    {
        Receiver.TreeList(_depth, new ConsoleOutput());
    }
}