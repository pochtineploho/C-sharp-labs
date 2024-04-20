using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.Fabrics;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class ConnectHandler : BaseHandler
{
    private const string CommandName = "connect";
    private string? _address;

    public ConnectHandler(IFileSystemOutput? receiver, BaseHandler? nextHandler = null)
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

        if (iterator.Count < 2) throw new WrongInputException();
        iterator.MoveNext();
        _address = iterator.Value;
        iterator.MoveNext();
        Flag flag = GetFlagWithValue(iterator);
        if (flag.Name != "mode" && flag.ShortName != "m") throw new WrongInputException();
        SetReceiver(new FileSystemFabric().GetByName(flag.Value ?? throw new WrongInputException()));

        return new Connect(Receiver, _address);
    }
}