using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class ConsoleParser : ParserBase
{
    public override string Read()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}