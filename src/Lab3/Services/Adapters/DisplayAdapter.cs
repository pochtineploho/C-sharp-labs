using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;

public class DisplayAdapter : IDisplay
{
    private readonly Display.Display _display;

    public DisplayAdapter(Display.Display display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));
    }

    public void Write(string text, Color color = default)
    {
        _display.Print(color, text);
    }

    public void Clear()
    {
        _display.Clear();
    }
}