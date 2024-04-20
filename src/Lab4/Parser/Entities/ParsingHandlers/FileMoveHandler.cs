using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class FileMoveHandler : BaseHandler
{
    private const string CommandName = "move";
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
        : base(receiver, nextHandler)
    {
    }

    public override IFileSystemCommand Handle(LineIterator iterator)
    {
        if (iterator == null || iterator.Count == 0) throw new EmptyLineException();
        if (iterator.Value != CommandName)
        {
            if (NextHandler is null) throw new WrongInputException();
            return NextHandler.Handle(iterator);
        }

        if (Receiver is null) throw new WrongInputException();
        if (iterator.Count < 3) throw new WrongInputException();
        iterator.MoveNext();
        _sourcePath = iterator.Value;
        iterator.MoveNext();
        _destinationPath = iterator.Value;
        iterator.MoveNext();

        return new FileMove(Receiver, _sourcePath, _destinationPath);
    }
}