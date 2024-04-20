using System;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

public class MyFile : FileSystemObject
{
    public MyFile(string name, string content)
        : base(name)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }

    public string Content { get; }

    public override void AcceptTreeVisitor(IDirectoryTreeVisitor visitor, string tabulation)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));
        visitor.AddFile(this, tabulation);
    }
}