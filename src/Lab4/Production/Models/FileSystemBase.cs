using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public abstract class FileSystemBase
{
    protected FileSystemBase(
        IFileReader fileReader,
        IDirectoryTraversal directoryTraversal)
    {
        FileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        DirectoryTraversal = directoryTraversal ?? throw new ArgumentNullException(nameof(directoryTraversal));
    }

    public IFileReader FileReader { get; }
    public IDirectoryTraversal DirectoryTraversal { get; }
}