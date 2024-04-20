using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class FileHandler : BaseHandler
{
    private const string CommandName = "file";
    private BaseHandler? _nextFileHandler;

    public FileHandler(IFileSystemOutput? receiver, BaseHandler? handler = null, BaseHandler? nextFileHandler = null)
        : base(receiver, handler)
    {
        _nextFileHandler = nextFileHandler;
    }

    public void SetNextFileHandler(BaseHandler handler)
    {
        _nextFileHandler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public override IFileSystemCommand Handle(LineIterator iterator)
    {
        if (iterator == null || iterator.Count == 0) throw new EmptyLineException();
        if (iterator.Value != CommandName)
        {
            if (NextHandler is null) throw new WrongInputException();
            return NextHandler.Handle(iterator);
        }

        iterator.MoveNext();
        if (_nextFileHandler is null) throw new WrongInputException();

        return _nextFileHandler.Handle(iterator);
    }
}