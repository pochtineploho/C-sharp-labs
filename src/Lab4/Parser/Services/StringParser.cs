using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class StringParser : ParserBase
{
    private readonly string _lineToParse;

    public StringParser(string lineToParse)
    {
        _lineToParse = lineToParse ?? throw new ArgumentNullException(nameof(lineToParse));
    }

    public override string Read()
    {
        return _lineToParse ?? string.Empty;
    }
}