using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public abstract class ComponentBase
{
    protected ComponentBase(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
    }

    public string Name { get; }
}