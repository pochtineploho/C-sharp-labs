using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class MotherboardRepository : RepositoryBase<Motherboard>
{
    public MotherboardRepository(IReadOnlyCollection<Motherboard> components)
        : base(components)
    { }
}