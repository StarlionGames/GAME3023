using UnityEngine;

public static class DamageCalculator
{
    public static int CalculateFlatDamage(Character attacker, Character target)
    {
        return attacker.ATK - target.DEF;
    }
}
