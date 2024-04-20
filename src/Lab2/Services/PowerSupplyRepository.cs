using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class PowerSupplyRepository : RepositoryBase<PowerSupply>
{
    public PowerSupplyRepository(IReadOnlyCollection<PowerSupply> components)
        : base(components)
    { }
}