namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

public interface IFileSystemCommand
{
    IFileSystemOutput? Receiver { get; }
    void Execute();
}