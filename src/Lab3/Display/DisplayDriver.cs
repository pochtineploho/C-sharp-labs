#pragma warning disable CA1822
using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayDriver
{
    private string _text;
    private Color _color;

    public DisplayDriver(string text = "", Color color = default)
    {
        _text = text ?? throw new ArgumentNullException(nameof(text));
        _color = color;
    }

    public void Print()
    {
        Console.Write(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(_text));
    }

    public void Clear()
    {
        Console.Clear();
        Console.ResetColor();
    }

    public void ChangeText(string text)
    {
        _text = $"{text}";
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }
}