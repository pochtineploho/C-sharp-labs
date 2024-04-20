#pragma warning disable CA1034

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.ForTests;

public abstract record CommandResult
{
    public record Connect(string Path) : CommandResult;

    public record Disconnect(bool Received) : CommandResult;

    public record TreeGoto(string Path) : CommandResult;

    public record TreeList(int Depth) : CommandResult;

    public record FileShow(string Path) : CommandResult;

    public record FileDelete(string Path) : CommandResult;

    public record FileMove(string SourcePath, string DestinationPath) : CommandResult;

    public record FileCopy(string SourcePath, string DestinationPath) : CommandResult;

    public record FileRename(string SourcePath, string Name) : CommandResult;
}
