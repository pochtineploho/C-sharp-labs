#pragma warning disable CA1822
using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

public class LocalFileSystem : FileSystemBase, IFileSystem
{
    private string? _fileSystemPath;

    public LocalFileSystem(
        IFileReader fileReader,
        IDirectoryTraversal directoryTraversal)
        : base(fileReader, directoryTraversal)
    { }

    public void Connect(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        if (_fileSystemPath is not null) throw new AlreadyConnectedException();

        _fileSystemPath = Path.Exists(path) ? path : throw new WrongPathException();
    }

    public void Disconnect()
    {
        if (_fileSystemPath is null) throw new ArgumentNullException(nameof(_fileSystemPath));

        _fileSystemPath = null;
    }

    public void TreeGoto(string path)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();
        if (path is null) throw new ArgumentNullException(nameof(path));

        _fileSystemPath = GetPath(path);
    }

    public MyDirectory TreeList(int depth)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();
        if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth));

        return DirectoryTraversal.GetTree(_fileSystemPath, depth);
    }

    public MyFile FileShow(string path)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();

        string fileWithPath = GetFilePath(path);
        return FileReader.ReadFile(fileWithPath);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();

        string fileWithPath = GetFilePath(sourcePath);
        string fileName = Path.GetFileName(fileWithPath);
        string newDirectory = GetDirectoryPath(destinationPath);
        string newFileWithPath = Path.Join(newDirectory, fileName);
        if (File.Exists(newFileWithPath)) throw new SameFileNameException();
        File.Move(fileWithPath, newFileWithPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();

        string fileWithPath = GetFilePath(sourcePath);
        string fileName = Path.GetFileName(fileWithPath);
        string newDirectory = GetDirectoryPath(destinationPath);
        string newFileWithPath = Path.Join(newDirectory, fileName);
        if (File.Exists(newFileWithPath)) throw new SameFileNameException();
        File.Copy(fileWithPath, newFileWithPath);
    }

    public void FileDelete(string path)
    {
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();

        string filePath = GetFilePath(path);
        File.Delete(filePath);
    }

    public void FileRename(string path, string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (_fileSystemPath is null) throw new HasNotConnectedYetException();

        string fileWithPath = GetFilePath(path);
        string fileDirectory = Path.GetDirectoryName(fileWithPath) ?? string.Empty;
        CheckName(name);
        string newFileWithPath = Path.Join(fileDirectory, name);
        if (File.Exists(newFileWithPath)) throw new SameFileNameException();
        File.Move(fileWithPath, newFileWithPath);
    }

    private string GetDirectoryPath(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string absolutePath = _fileSystemPath + "\\" + path;
        return Directory.Exists(path) ? path
            : Directory.Exists(absolutePath) ? absolutePath
            : throw new WrongPathException();
    }

    private string GetFilePath(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string absolutePath = _fileSystemPath + "\\" + path;
        return File.Exists(path) ? path
            : File.Exists(absolutePath) ? absolutePath
            : throw new WrongPathException();
    }

    private string GetPath(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string absolutePath = _fileSystemPath + "\\" + path;
        return Path.Exists(path) ? path
            : Path.Exists(absolutePath) ? absolutePath
            : throw new WrongPathException();
    }

    private void CheckName(string name)
    {
        if (name.Contains('\\', StringComparison.Ordinal) || name.Contains('/', StringComparison.Ordinal))
            throw new WrongInputException();
    }
}