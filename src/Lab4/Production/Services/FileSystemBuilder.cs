using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class FileSystemBuilder
{
    private IFileReader? _fileReader;
    private IFileTexifyer? _fileHandler;
    private IDirectoryTraversal? _directoryTraversal;
    private IDirectoryTreeVisitor? _directoryTreeHandler;

    public FileSystemBuilder WithFileReader(IFileReader fileReader)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));

        return this;
    }

    public FileSystemBuilder WithFileHandler(IFileTexifyer fileTexifyer)
    {
        _fileHandler = fileTexifyer ?? throw new ArgumentNullException(nameof(fileTexifyer));

        return this;
    }

    public FileSystemBuilder WithDirectoryTraversal(IDirectoryTraversal directoryTraversal)
    {
        _directoryTraversal = directoryTraversal ?? throw new ArgumentNullException(nameof(directoryTraversal));

        return this;
    }

    public FileSystemBuilder WithDirectoryTreeHandler(IDirectoryTreeVisitor directoryTreeVisitor)
    {
        _directoryTreeHandler = directoryTreeVisitor ?? throw new ArgumentNullException(nameof(directoryTreeVisitor));

        return this;
    }

    public IFileSystemOutput BuildLocalFileSystem()
    {
        if (_fileReader is null) throw new ArgumentNullException(nameof(_fileReader));
        if (_fileHandler is null) throw new ArgumentNullException(nameof(_fileHandler));
        if (_directoryTraversal is null) throw new ArgumentNullException(nameof(_directoryTraversal));
        if (_directoryTreeHandler is null) throw new ArgumentNullException(nameof(_directoryTreeHandler));

        return new DefaultFileSystemOutput(new LocalFileSystem(_fileReader, _directoryTraversal), _directoryTreeHandler, _fileHandler);
    }

    public IFileSystemOutput BuildTestFileSystem()
    {
        if (_fileHandler is null) throw new ArgumentNullException(nameof(_fileHandler));
        if (_directoryTreeHandler is null) throw new ArgumentNullException(nameof(_directoryTreeHandler));

        return new DefaultFileSystemOutput(new TestFileSystem(), _directoryTreeHandler, _fileHandler);
    }
}