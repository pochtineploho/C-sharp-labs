#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class AntimatterFlaresCrewDeadTest
{
    [Theory]
    [MemberData(nameof(TestInlineDataGenerator.Case2TestData), MemberType = typeof(TestInlineDataGenerator))]
    public void TryToFly(SpaceShip.Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        var flyingService = new FlyingService();

        Results.Models.Results result = flyingService.CheckTheRoute(spaceShip, environment);

        Assert.Equal(
            spaceShip.Deflector.Modifications.PhotonicDeflector is null ? ResultCases.CrewDead : ResultCases.Success,
            result.Result);
    }
}