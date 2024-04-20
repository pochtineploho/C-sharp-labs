#pragma warning disable CA1822
using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger
{
    public void Print(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
        Console.WriteLine(text);
    }
}