using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class ParsingHandler
{
    private BaseHandler _handler;

    public ParsingHandler(BaseHandler? handler = null)
    {
        _handler = handler ?? new HandlerDirector().BuildDefaultHandlerSystem();
    }

    public IReadOnlyCollection<IFileSystemCommand> Handle(LineIterator iterator)
    {
        if (iterator == null) throw new ArgumentNullException(nameof(iterator));
        var resultCommands = new List<IFileSystemCommand>();
        while (iterator.Count > 0)
        {
            IFileSystemCommand command = _handler.Handle(iterator);
            if (command is Connect) _handler = new HandlerDirector().BuildDefaultHandlerSystem(command.Receiver);
            resultCommands.Add(command);
        }

        return resultCommands;
    }
}