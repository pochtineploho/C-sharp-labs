using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;

public class StrongArmor : ArmorBase
{
    private const int HitPoints = 1800;
    public StrongArmor()
        : base(HitPoints) { }
}