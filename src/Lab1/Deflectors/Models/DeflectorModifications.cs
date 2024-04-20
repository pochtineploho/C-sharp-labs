using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;

public class DeflectorModifications
{
    public DeflectorModifications()
    {
        PhotonicDeflector = null;
    }

    public DeflectorModifications(PhotonicDeflector? photonicDeflector)
    {
        PhotonicDeflector = photonicDeflector;
    }

    public PhotonicDeflector? PhotonicDeflector { get; set; }
}