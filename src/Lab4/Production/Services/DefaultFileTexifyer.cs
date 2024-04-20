using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class DefaultFileTexifyer : IFileTexifyer
{
    public string FileToText(MyFile file)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        return file.Content;
    }
}