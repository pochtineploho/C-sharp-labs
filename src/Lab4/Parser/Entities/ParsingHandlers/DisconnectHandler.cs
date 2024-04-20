using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class DisconnectHandler : BaseHandler
{
    private const string CommandName = "disconnect";

    public DisconnectHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
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

        return new Disconnect(Receiver);
    }
}