#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class WifiAdapterProblemsBuildTest
{
    [Theory]
    [MemberData(
        nameof(TestDataGenerator.WifiAdapterProblemsBuildTestData),
        MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(ComputerBuilder builder)
    {
        try
        {
            builder.GetResult();
        }
        catch (IncompatibleComponentsException exception)
        {
            Assert.Equal(
                "Network equipment conflict: motherboard has integrated Wi-Fi adapter, can't use an external one",
                exception.Message);
        }
    }
}