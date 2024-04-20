#pragma warning disable CA1822
using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public abstract class BaseHandler
{
    protected BaseHandler(IFileSystemOutput? receiver = null, BaseHandler? nextHandler = null)
    {
        Receiver = receiver;
        NextHandler = nextHandler;
    }

    public IFileSystemOutput? Receiver { get; private set; }
    protected BaseHandler? NextHandler { get; private set; }

    public abstract IFileSystemCommand Handle(LineIterator iterator);

    public void SetNext(BaseHandler? commandHandler)
    {
        NextHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    protected void SetReceiver(IFileSystemOutput receiver)
    {
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    protected Flag GetFlagWithValue(LineIterator iterator)
    {
        return TryGetFlagWithValue(iterator) ?? throw new WrongInputException();
    }

    protected Flag? TryGetFlagWithValue(LineIterator iterator)
    {
        if (iterator == null) throw new ArgumentNullException(nameof(iterator));
        if (iterator.Count == 0) return null;
        if (!iterator.Value.StartsWith('-')) return null;
        if (iterator.Value.StartsWith("--", StringComparison.Ordinal))
        {
            string name = iterator.Value[2..];
            iterator.MoveNext();

            var flag = new Flag(name, null, iterator.Value);
            iterator.MoveNext();

            return flag;
        }
        else
        {
            string shortName = iterator.Value[1..];
            iterator.MoveNext();

            var flag = new Flag(null, shortName, iterator.Value);
            iterator.MoveNext();

            return flag;
        }
    }
}