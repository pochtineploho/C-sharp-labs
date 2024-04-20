using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class WarningPowerBuildTest
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.WarningPowerBuildTestData), MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(Computer computer)
    {
        var orderGenerator = new OrderGenerator(computer);

        Order order = orderGenerator.SendOrder();

        Assert.IsType<ComputerValidationResult.Warning>(orderGenerator.Result);
        Assert.Equal("Warning: power consumption is too high for this power supply unit", order.Comment);
    }
}