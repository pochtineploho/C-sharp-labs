using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class BiosRepository : RepositoryBase<Bios>
{
    public BiosRepository(IReadOnlyCollection<Bios> components)
        : base(components)
    { }
}