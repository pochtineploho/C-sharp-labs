using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class TreeHandler : BaseHandler
{
    private const string CommandName = "tree";
    private BaseHandler? _nextTreeHandler;

    public TreeHandler(IFileSystemOutput? receiver, BaseHandler? handler = null, BaseHandler? nextTreeHandler = null)
        : base(receiver, handler)
    {
        _nextTreeHandler = nextTreeHandler;
    }

    public void SetNextTreeHandler(BaseHandler handler)
    {
        _nextTreeHandler = handler ?? throw new ArgumentNullException(nameof(handler));
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
        if (_nextTreeHandler is null) throw new WrongInputException();

        return _nextTreeHandler.Handle(iterator);
    }
}