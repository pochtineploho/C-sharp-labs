using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IDirectoryTraversal
{
    MyDirectory GetTree(string path, int depth);
}