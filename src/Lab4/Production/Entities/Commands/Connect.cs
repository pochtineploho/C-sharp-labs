using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class Connect : IFileSystemCommand
{
    private readonly string _address;

    public Connect(IFileSystemOutput? receiver, string address)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public IFileSystemOutput Receiver { get; }
    public void Execute()
    {
        Receiver.Connect(_address);
    }
}