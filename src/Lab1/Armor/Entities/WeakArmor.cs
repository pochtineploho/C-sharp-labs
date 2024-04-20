using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Entities;

public class WeakArmor : ArmorBase
{
    private const int HitPoints = 100;
    public WeakArmor()
        : base(HitPoints) { }
}