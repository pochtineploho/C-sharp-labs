using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public class DefaultFileSystemOutput : FileSystemOutputBase, IFileSystemOutput
{
    public DefaultFileSystemOutput(
        IFileSystem fileSystem,
        IDirectoryTreeVisitor directoryTreeVisitor,
        IFileTexifyer fileTexifyer,
        IOutput? output = null)
        : base(fileSystem, directoryTreeVisitor, fileTexifyer, output)
    { }

    public void Connect(string path)
    {
        FileSystem.Connect(path);
    }

    public void Disconnect()
    {
        FileSystem.Disconnect();
    }

    public void TreeGoto(string path)
    {
        FileSystem.TreeGoto(path);
    }

    public MyDirectory TreeList(int depth)
    {
        return FileSystem.TreeList(depth);
    }

    public MyFile FileShow(string path)
    {
        return FileSystem.FileShow(path);
    }

    public void TreeList(int depth, IOutput output)
    {
        Output = output ?? throw new ArgumentNullException(nameof(output));
        MyDirectory directory = TreeList(depth);
        string text = DirectoryTreeVisitor.TreeToText(directory);
        Output.Print(text);
    }

    public void FileShow(string path, IOutput output)
    {
        Output = output ?? throw new ArgumentNullException(nameof(output));
        MyFile file = FileShow(path);
        string text = FileTexifyer.FileToText(file);
        Output.Print(text);
    }

    public IFileSystem GetReceiverFileSystem()
    {
        return FileSystem;
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        FileSystem.FileMove(sourcePath, destinationPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        FileSystem.FileCopy(sourcePath, destinationPath);
    }

    public void FileDelete(string path)
    {
        FileSystem.FileDelete(path);
    }

    public void FileRename(string path, string name)
    {
        FileSystem.FileRename(path, name);
    }
}