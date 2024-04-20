using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

public record Flag
{
    public Flag(string? name, string? shortName, string? value)
    {
        if (shortName is null && name is null) throw new WrongFlagNameException();
        ShortName = shortName;
        Name = name;
        Value = value;
    }

    public string? ShortName { get; }
    public string? Name { get; }
    public string? Value { get; }
}