using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;

public class MediumArmor : ArmorBase
{
    private const int HitPoints = 600;
    public MediumArmor()
        : base(HitPoints) { }
}