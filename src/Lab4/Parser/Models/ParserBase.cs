using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

public abstract class ParserBase
{
    public IReadOnlyCollection<IFileSystemCommand> Parse()
    {
        string[] line = Read().Split();

        return new ParsingHandler().Handle(new LineIterator(line));
    }

    public abstract string Read();
}