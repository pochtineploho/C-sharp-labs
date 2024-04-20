using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class MediumLengthIncreasedDensityShipLostTest
{
    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case1TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFly(SpaceShip.Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environment);

        Assert.Equal(ResultCases.ShipLost, result.Result);
    }
}