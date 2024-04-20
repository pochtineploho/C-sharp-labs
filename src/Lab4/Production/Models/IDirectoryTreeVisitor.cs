using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IDirectoryTreeVisitor
{
    string TreeToText(MyDirectory directory);

    void AddFile(MyFile file, string tabulation);
    void AddDirectory(MyDirectory directory, string tabulation);
}