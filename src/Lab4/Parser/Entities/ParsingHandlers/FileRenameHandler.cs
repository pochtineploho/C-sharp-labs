using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class FileRenameHandler : BaseHandler
{
    private const string CommandName = "rename";
    private string? _sourcePath;
    private string? _name;

    public FileRenameHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
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
        _name = iterator.Value;
        iterator.MoveNext();

        return new FileRename(Receiver, _sourcePath, _name);
    }
}