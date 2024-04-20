using System;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.JumpingEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Mass.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class SpaceShip
{
    public SpaceShip(
        ImpulseEngineBase impulseEngine,
        JumpingEngineBase? jumpingEngine,
        ArmorBase armor,
        MassBase mass,
        DeflectorBase? deflector,
        ShipModifications? shipModifications)
    {
        IsIntact = true;
        CrewIsAlive = true;
        ImpulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        JumpingEngine = jumpingEngine;
        Armor = armor ?? throw new ArgumentNullException(nameof(armor));
        Mass = mass ?? throw new ArgumentNullException(nameof(mass));
        Deflector = deflector ?? new NullDeflector();
        ShipModifications = shipModifications ?? new ShipModifications();
    }

    public bool CrewIsAlive { get; private set; }
    public bool IsIntact { get; private set; }
    public MassBase Mass { get; }
    public ArmorBase Armor { get; }
    public DeflectorBase Deflector { get; }
    public JumpingEngineBase? JumpingEngine { get; }
    public ImpulseEngineBase ImpulseEngine { get; }
    public ShipModifications ShipModifications { get; }
    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is null) throw new ArgumentNullException(nameof(obstacle));
        Deflector.TakeDamage(obstacle);
        Armor.TakeDamage(obstacle);

        if (obstacle.Damage > 0)
        {
            IsIntact = false;
        }
    }

    public void RunInto(Meteorite meteorite)
    {
        TakeDamage(meteorite);
    }

    public void RunInto(SmallAsteroid smallAsteroid)
    {
        TakeDamage(smallAsteroid);
    }

    public void RunInto(AntimatterFlares antimatterFlares)
    {
        if (Deflector.Modifications.PhotonicDeflector is not null)
        {
            if (Deflector.Modifications.PhotonicDeflector.TryToUseAbility()) return;
        }

        CrewIsAlive = false;
        TakeDamage(antimatterFlares);
    }

    public void RunInto(SpaceWhale spaceWhale)
    {
        if (ShipModifications.AntiNitrineEmitter is not null)
        {
            if (ShipModifications.AntiNitrineEmitter.TryToUseAbility()) return;
        }

        TakeDamage(spaceWhale);
    }
}
