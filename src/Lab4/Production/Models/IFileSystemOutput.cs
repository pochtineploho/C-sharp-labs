namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IFileSystemOutput : IFileSystem
{
    void TreeList(int depth, IOutput output);

    public void FileShow(string path, IOutput output);

    public IFileSystem GetReceiverFileSystem();
}