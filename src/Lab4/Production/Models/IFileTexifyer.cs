using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IFileTexifyer
{
    string FileToText(MyFile file);
}