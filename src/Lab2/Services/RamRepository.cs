using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class RamRepository : RepositoryBase<Ram>
{
    public RamRepository(IReadOnlyCollection<Ram> components)
        : base(components)
    { }
}