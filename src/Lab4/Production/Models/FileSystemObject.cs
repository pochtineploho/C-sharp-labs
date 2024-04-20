using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public abstract class FileSystemObject
{
    protected FileSystemObject(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; }
    public abstract void AcceptTreeVisitor(IDirectoryTreeVisitor visitor, string tabulation);
}