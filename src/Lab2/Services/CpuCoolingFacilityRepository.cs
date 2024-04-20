using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class CpuCoolingFacilityRepository : RepositoryBase<CpuCoolingFacility>
{
    public CpuCoolingFacilityRepository(IReadOnlyCollection<CpuCoolingFacility> components)
        : base(components)
    { }
}