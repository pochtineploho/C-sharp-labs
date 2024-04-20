using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class SsdRepository : RepositoryBase<Ssd>
{
    public SsdRepository(IReadOnlyCollection<Ssd> components)
        : base(components)
    { }
}