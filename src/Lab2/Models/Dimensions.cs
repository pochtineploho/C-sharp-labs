using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Dimensions
{
    public Dimensions(double length, double width, double height)
    {
        Length = length <= 0 ? throw new ArgumentOutOfRangeException(nameof(length)) : length;
        Width = width <= 0 ? throw new ArgumentOutOfRangeException(nameof(width)) : width;
        Height = height <= 0 ? throw new ArgumentOutOfRangeException(nameof(height)) : height;
    }

    public double Length { get; }
    public double Width { get; }
    public double Height { get; }

    public bool FitsIn(Dimensions size)
    {
        if (size is null) throw new ArgumentNullException(nameof(size));

        return Length <= size.Length && Width <= size.Width && Height <= size.Height;
    }
}