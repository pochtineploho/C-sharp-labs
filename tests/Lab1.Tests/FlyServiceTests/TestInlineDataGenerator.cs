using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.FlyServiceTests;

public class TestInlineDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> Case1TestData => new List<object[]>
    {
        new object[]
        {
            new WalkingShuttle(),
            new IncreasedDensityNebula(),
        },
        new object[]
        {
            new WalkingShuttle(),
            new IncreasedDensityNebula(null, 20000),
        },
        new object[]
        {
            new WalkingShuttle(),
            new IncreasedDensityNebula(null, 35000),
        },
        new object[]
        {
            new Avgur(),
            new IncreasedDensityNebula(),
        },
        new object[]
        {
            new Avgur(),
            new IncreasedDensityNebula(null, 20000),
        },
        new object[]
        {
            new Avgur(),
            new IncreasedDensityNebula(null, 35000),
        },
    };

    public static IEnumerable<object[]> Case2TestData => new List<object[]>
    {
        new object[]
        {
            new Vaklas(),
            new IncreasedDensityNebula(new[] { new AntimatterFlares() }),
        },
        new object[]
        {
            new Vaklas(new DeflectorModifications(new PhotonicDeflector())),
            new IncreasedDensityNebula(new[] { new AntimatterFlares() }),
        },
    };

    public static IEnumerable<object[]> Case31TestData => new List<object[]>
    {
        new object[]
        {
            new Vaklas(),
            new NitrideParticlesNebula(new[] { new SpaceWhale() }),
        },
    };

    public static IEnumerable<object[]> Case32TestData => new List<object[]>
    {
        new object[]
        {
            new Avgur(),
            new NitrideParticlesNebula(new[] { new SpaceWhale() }),
        },
    };

    public static IEnumerable<object[]> Case33TestData => new List<object[]>
    {
        new object[]
        {
            new Meridian(),
            new NitrideParticlesNebula(new[] { new SpaceWhale() }),
        },
    };

    public static IEnumerable<object[]> Case4TestData => new List<object[]>
    {
        new object[]
        {
            new WalkingShuttle(),
            new Vaklas(),
            new CommonSpace(),
        },
    };

    public static IEnumerable<object[]> Case5TestData => new List<object[]>
    {
        new object[]
        {
            new WalkingShuttle(),
            new Vaklas(),
            new NitrideParticlesNebula(),
        },
    };

    public static IEnumerable<object[]> Case61TestData => new List<object[]>
    {
        new object[]
        {
            new Vaklas(new DeflectorModifications(new PhotonicDeflector())),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(null, 276541),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(3), new Meteorite(2) }, 42069),
                new IncreasedDensityNebula(new[] { new AntimatterFlares(3) }, 75000),
            },
        },
        new object[]
        {
            new Meridian(),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(new[] { new SpaceWhale(5), new SpaceWhale(7) }, 276541),
                new CommonSpace(new ObstacleBase[] { new Meteorite(2) }, 40),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(2) }, 42069),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(1), new SmallAsteroid(2) }, 4),
            },
        },
    };

    public static IEnumerable<object[]> Case62TestData => new List<object[]>
    {
        new object[]
        {
            new Vaklas(new DeflectorModifications(new PhotonicDeflector())),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(null, 276541),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(3), new Meteorite(2) }, 42069),
                new IncreasedDensityNebula(new[] { new AntimatterFlares(4) }, 75000),
            },
        },
        new object[]
        {
            new Stella(),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(null, 276541),
                new CommonSpace(null, 40),
                new IncreasedDensityNebula(new[] { new AntimatterFlares() }, 10000),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(2) }, 42069),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(), new SmallAsteroid(2) }, 4),
            },
        },
    };

    public static IEnumerable<object[]> Case63TestData => new List<object[]>
    {
        new object[]
        {
            new Avgur(new DeflectorModifications(new PhotonicDeflector())),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(null, 276541),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(3), new Meteorite(2) }, 42069),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(3), new Meteorite(25) }, 42069),
            },
        },
        new object[]
        {
            new Stella(),
            new EnvironmentBase[]
            {
                new CommonSpace(null, 40),
                new NitrideParticlesNebula(new[] { new SpaceWhale() }, 276541),
                new IncreasedDensityNebula(new[] { new AntimatterFlares() }, 10000),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(2) }, 42069),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(), new SmallAsteroid(2) }, 4),
            },
        },
    };
    public static IEnumerable<object[]> Case64TestData => new List<object[]>
    {
        new object[]
        {
            new Vaklas(new DeflectorModifications(new PhotonicDeflector())),
            new EnvironmentBase[]
            {
                new NitrideParticlesNebula(null, 276541),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(3), new Meteorite(2) }, 42069),
                new IncreasedDensityNebula(new[] { new AntimatterFlares(4) }, 1000000),
            },
        },
        new object[]
        {
            new WalkingShuttle(),
            new EnvironmentBase[]
            {
                new CommonSpace(null, 40),
                new NitrideParticlesNebula(null, 276541),
                new IncreasedDensityNebula(null, 10000),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(2) }, 42069),
                new CommonSpace(new ObstacleBase[] { new SmallAsteroid(), new SmallAsteroid(2) }, 4),
            },
        },
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}