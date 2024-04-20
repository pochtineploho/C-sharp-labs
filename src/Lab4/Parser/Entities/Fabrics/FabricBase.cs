using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.Fabrics;

public class FabricBase<T> : IFabric<T>
{
    private readonly List<FabricType<T>> _list;

    public FabricBase(IReadOnlyCollection<FabricType<T>> list)
    {
        _list = new List<FabricType<T>>(list ?? throw new ArgumentNullException(nameof(list)));
    }

    public T GetByName(string name)
    {
        return _list.First(arg => arg.Name == name).Result ?? throw new WrongInputException();
    }
}