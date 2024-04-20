using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class ShortLengthCommonSpaceBestPriceTest
{
    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case4TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFly(SpaceShip.Entities.SpaceShip walkingShuttle, SpaceShip.Entities.SpaceShip valkas, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        FinalResult result = flyingService.CompareShips(new[] { walkingShuttle, valkas }, new[] { environment });

        Assert.False(result.BestPrice is null);
        Assert.True(result.BestPrice.SpaceShip is WalkingShuttle);
    }
}