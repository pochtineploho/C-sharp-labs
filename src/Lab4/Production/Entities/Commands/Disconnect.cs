using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class Disconnect : IFileSystemCommand
{
    public Disconnect(IFileSystemOutput? receiver)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public IFileSystemOutput Receiver { get; }
    public void Execute()
    {
        Receiver.Disconnect();
    }
}