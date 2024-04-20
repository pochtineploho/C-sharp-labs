using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;

public class MyDirectory : FileSystemObject
{
    private readonly List<FileSystemObject> _content;

    public MyDirectory(string name, IReadOnlyCollection<FileSystemObject>? content = null)
        : base(name)
    {
        _content = new List<FileSystemObject>(content ?? new List<FileSystemObject>());
    }

    public IReadOnlyList<FileSystemObject> Content => _content;

    public void AddObject(FileSystemObject systemObject)
    {
        _content.Add(systemObject);
    }

    public void RemoveObject(FileSystemObject systemObject)
    {
        _content.Remove(systemObject);
    }

    public override void AcceptTreeVisitor(IDirectoryTreeVisitor visitor, string tabulation)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));
        visitor.AddDirectory(this, tabulation);
    }
}