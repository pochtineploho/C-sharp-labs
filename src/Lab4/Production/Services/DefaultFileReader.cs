using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class DefaultFileReader : IFileReader
{
    public MyFile ReadFile(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        return new MyFile(Path.GetFileName(path), File.ReadAllText(path) + "\n");
    }
}
