using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class PhotonicDeflector : IModification
{
    public PhotonicDeflector()
    {
        UsagesLeft = 3;
    }

    private int UsagesLeft { get; set; }

    public bool TryToUseAbility()
    {
        UsagesLeft--;
        return UsagesLeft >= 0;
    }
}