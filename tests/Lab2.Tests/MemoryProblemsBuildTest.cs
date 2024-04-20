#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MemoryProblemsBuildTest
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.MemoryProblemsBuildTestData), MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(ComputerBuilder builder)
    {
        try
        {
            builder.GetResult();
        }
        catch (IncompatibleComponentsException exception)
        {
            Assert.Equal("Not enough PCI-E slots", exception.Message);
        }
    }
}