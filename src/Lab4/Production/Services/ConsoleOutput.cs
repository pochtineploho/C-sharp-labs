using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class ConsoleOutput : IOutput
{
    public void Print(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        Console.Write(text);
    }
}