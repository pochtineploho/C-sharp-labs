#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class GpuProblemsBuildTest
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.GpuProblemsBuildTestData), MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(ComputerBuilder builder)
    {
        try
        {
            builder.GetResult();
        }
        catch (IncompatibleComponentsException exception)
        {
            Assert.True(exception.Message is "There is no graphics processor" or "GPU doesn't fit in the case");
        }
    }
}