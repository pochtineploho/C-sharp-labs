using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;

public class FileCopy : IFileSystemCommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileCopy(IFileSystemOutput receiver, string sourcePath, string destinationPath)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        _sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        _destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public IFileSystemOutput Receiver { get; }

    public void Execute()
    {
        Receiver.FileCopy(_sourcePath, _destinationPath);
    }
}