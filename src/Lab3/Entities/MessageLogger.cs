using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageLogger : ILogger
{
    public void Log(string text)
    {
        Console.Write("Logger: Message received! " + text);
    }
}