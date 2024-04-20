using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Models;

public class ShipModifications
{
    public ShipModifications()
    {
        AntiNitrineEmitter = null;
    }

    public ShipModifications(AntiNitrineEmitter? antiNitrineEmitter)
    {
        AntiNitrineEmitter = antiNitrineEmitter;
    }

    public AntiNitrineEmitter? AntiNitrineEmitter { get; set; }
}