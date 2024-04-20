using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public sealed class WifiAdapterRepository : RepositoryBase<WifiAdapter>
{
    public WifiAdapterRepository(IReadOnlyCollection<WifiAdapter> components)
        : base(components)
    { }
}