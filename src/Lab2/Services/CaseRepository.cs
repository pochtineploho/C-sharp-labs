using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class CaseRepository : RepositoryBase<ComputerCase>
{
    public CaseRepository(IReadOnlyCollection<ComputerCase> components)
        : base(components)
    { }
}