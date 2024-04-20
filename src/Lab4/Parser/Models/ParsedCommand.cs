using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

public class ParsedCommand
{
    private readonly List<Flag> _flags;

    public ParsedCommand(string name, IReadOnlyCollection<Flag>? flags = null)
    {
        _flags = new List<Flag>(flags ?? new List<Flag>());
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public IReadOnlyList<Flag> Flags => _flags;

    public string Name { get; }

    public void AddFlag(Flag flag)
    {
        _flags.Add(flag);
    }
}