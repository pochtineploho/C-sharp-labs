using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepositoryBase<T> : IRepository<T>
    where T : ComponentBase
{
    private List<T> _components;

    public RepositoryBase(IReadOnlyCollection<T> components)
    {
        if (components is null) throw new ArgumentNullException(nameof(components));
        _components = new List<T>(components);
    }

    public T GetByName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        return _components.FirstOrDefault(component =>
                   component.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) ??
               throw new ArgumentOutOfRangeException(nameof(name));
    }

    public IRepository<T> Add(T component)
    {
        if (component is null) throw new ArgumentNullException(nameof(component));
        _components.Add(component);

        return this;
    }
}