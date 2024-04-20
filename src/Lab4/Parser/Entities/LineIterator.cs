using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;

public class LineIterator
{
    private readonly ReadOnlyCollection<string> _list;
    private readonly IEnumerator<string> _enumerator;
    private int _skipped;

    public LineIterator(string[] list)
        : this(new ReadOnlyCollection<string>(list))
    { }

    public LineIterator(ReadOnlyCollection<string> list)
    {
        _list = list ?? throw new ArgumentNullException(nameof(list));
        _enumerator = _list.GetEnumerator();
        _enumerator.MoveNext();
        _skipped = 0;
    }

    public int Count => _list.Count - _skipped;

    public string Value => _enumerator.Current;

    public void MoveNext()
    {
        _enumerator.MoveNext();
        _skipped++;
    }
}