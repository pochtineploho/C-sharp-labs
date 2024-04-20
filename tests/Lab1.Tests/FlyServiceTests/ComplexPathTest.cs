using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class ComplexPathTest
{
    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case61TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlySuccessfully(SpaceShip.Entities.SpaceShip spaceShip, IReadOnlyCollection<EnvironmentBase> environments)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environments);

        Assert.Equal(ResultCases.Success, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case62TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyCrewDead(SpaceShip.Entities.SpaceShip spaceShip, IReadOnlyCollection<EnvironmentBase> environments)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environments);

        Assert.Equal(ResultCases.CrewDead, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case63TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyShipDestroyed(SpaceShip.Entities.SpaceShip spaceShip, IReadOnlyCollection<EnvironmentBase> environments)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environments);

        Assert.Equal(ResultCases.ShipDestroyed, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case64TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyShipShipLost(SpaceShip.Entities.SpaceShip spaceShip, IReadOnlyCollection<EnvironmentBase> environments)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environments);

        Assert.Equal(ResultCases.ShipLost, result.Result);
    }
}