using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;

public class TestFileSystem : FileSystemBase, IFileSystem
{
    public TestFileSystem()
        : base(
            new DefaultFileReader(),
            new DefaultTraversal())
    { }

    public CommandResult? Result { get; private set; }

    public void Connect(string path)
    {
        Result = new CommandResult.Connect(path);
    }

    public void Disconnect()
    {
        Result = new CommandResult.Disconnect(true);
    }

    public void TreeGoto(string path)
    {
        Result = new CommandResult.TreeGoto(path);
    }

    public MyDirectory TreeList(int depth)
    {
        Result = new CommandResult.TreeList(depth);
        return new MyDirectory(string.Empty, System.Array.Empty<FileSystemObject>());
    }

    public MyFile FileShow(string path)
    {
        Result = new CommandResult.FileShow(path);
        return new MyFile(string.Empty, string.Empty);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        Result = new CommandResult.FileMove(sourcePath, destinationPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        Result = new CommandResult.FileCopy(sourcePath, destinationPath);
    }

    public void FileDelete(string path)
    {
        Result = new CommandResult.FileDelete(path);
    }

    public void FileRename(string path, string name)
    {
        Result = new CommandResult.FileRename(path, name);
    }
}