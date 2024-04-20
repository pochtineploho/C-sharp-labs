#pragma warning disable CA1822
using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display
{
    private readonly DisplayDriver _driver;

    public Display(DisplayDriver driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
    }

    public void Print(Color color, string text)
    {
        _driver.Clear();
        _driver.ChangeColor(color);
        _driver.ChangeText(text);
        _driver.Print();
    }

    public void Clear()
    {
        Console.Clear();
        Console.ResetColor();
    }
}