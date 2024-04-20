using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class GpuRepository : RepositoryBase<Gpu>
{
    public GpuRepository(IReadOnlyCollection<Gpu> components)
        : base(components)
    { }
}