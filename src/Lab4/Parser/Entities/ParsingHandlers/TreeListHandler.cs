using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class TreeListHandler : BaseHandler
{
    private const string CommandName = "list";
    private int _depth;

    public TreeListHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
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

        iterator.MoveNext();
        if (Receiver is null) throw new WrongInputException();
        Flag? flag = TryGetFlagWithValue(iterator);
        if (flag is null) return new TreeList(Receiver);

        if (flag.Name == "depth" || flag.ShortName == "d")
        {
            _depth = Convert.ToInt32(flag.Value, null);
        }

        return new TreeList(Receiver, _depth);
    }
}