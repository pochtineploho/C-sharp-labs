using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class WeakCoolerBuildTest
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.WeakCoolerBuildTestData), MemberType = typeof(TestDataGenerator))]
    public void TryToBuild(Computer computer)
    {
        var orderGenerator = new OrderGenerator(computer);

        Order order = orderGenerator.SendOrder();

        Assert.IsType<ComputerValidationResult.DisclaimerOfWarranty>(orderGenerator.Result);
        Assert.Equal("CPU heat dissipation is too high for cooling facility", order.Comment);
    }
}