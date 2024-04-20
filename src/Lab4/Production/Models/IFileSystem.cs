using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IFileSystem
{
    void Connect(string path);

    void Disconnect();

    void TreeGoto(string path);

    MyDirectory TreeList(int depth);

    MyFile FileShow(string path);

    void FileMove(string sourcePath, string destinationPath);

    void FileCopy(string sourcePath, string destinationPath);

    void FileDelete(string path);

    void FileRename(string path, string name);
}