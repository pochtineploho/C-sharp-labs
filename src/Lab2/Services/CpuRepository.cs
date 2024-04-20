using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class CpuRepository : RepositoryBase<Cpu>
{
    public CpuRepository(IReadOnlyCollection<Cpu> components)
        : base(components)
    { }
}