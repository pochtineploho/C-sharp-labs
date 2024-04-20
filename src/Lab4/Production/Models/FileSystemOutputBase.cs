using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public class FileSystemOutputBase
{
    public FileSystemOutputBase(IFileSystem fileSystem, IDirectoryTreeVisitor directoryTreeVisitor, IFileTexifyer fileTexifyer, IOutput? output = null)
    {
        FileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        DirectoryTreeVisitor = directoryTreeVisitor ?? throw new ArgumentNullException(nameof(directoryTreeVisitor));
        FileTexifyer = fileTexifyer ?? throw new ArgumentNullException(nameof(fileTexifyer));
        Output = output;
    }

    protected IOutput? Output { get; set; }
    protected IFileSystem FileSystem { get; }
    protected IDirectoryTreeVisitor DirectoryTreeVisitor { get; }
    protected IFileTexifyer FileTexifyer { get; }
}