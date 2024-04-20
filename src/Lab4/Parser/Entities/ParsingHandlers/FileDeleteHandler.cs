using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class FileDeleteHandler : BaseHandler
{
    private const string CommandName = "delete";
    private string? _path;

    public FileDeleteHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
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
        if (iterator.Count < 2) throw new WrongInputException();
        iterator.MoveNext();
        _path = iterator.Value;
        iterator.MoveNext();

        return new FileDelete(Receiver, _path);
    }
}