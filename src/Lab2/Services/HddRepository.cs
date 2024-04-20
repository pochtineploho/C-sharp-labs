using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class HddRepository : RepositoryBase<Hdd>
{
    public HddRepository(IReadOnlyCollection<Hdd> components)
        : base(components)
    { }
}