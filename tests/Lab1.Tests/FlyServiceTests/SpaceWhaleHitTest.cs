#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class SpaceWhaleHitTest
{
    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case31TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyValkas(SpaceShip.Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environment);

        Assert.Equal(ResultCases.ShipDestroyed, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case32TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyAvgur(SpaceShip.Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environment);

        Assert.Equal(ResultCases.Success, result.Result);
        Assert.Equal(spaceShip.Armor.HealthPoints, new Avgur().Armor.HealthPoints);
        Assert.Equal(0, spaceShip.Deflector.HealthPoints);
    }

    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case33TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFlyMeredian(SpaceShip.Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environment);

        Assert.Equal(ResultCases.Success, result.Result);
        Assert.Equal(spaceShip.Deflector.HealthPoints, new Meridian().Deflector.HealthPoints);
    }
}