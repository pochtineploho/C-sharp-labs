#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class RamDdrBuildTest
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.RamDdrBuildTestData), MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(ComputerBuilder builder)
    {
        try
        {
            builder.GetResult();
        }
        catch (IncompatibleComponentsException exception)
        {
            Assert.Equal("RAM doesn't match motherboard's DDR standard", exception.Message);
        }
    }
}