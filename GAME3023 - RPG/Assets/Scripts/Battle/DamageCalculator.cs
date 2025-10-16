using UnityEngine;

public static class DamageCalculator
{
    public static int CalculateFlatDamage(Character attacker, Character target, int power)
    {
        float levelMult = ((attacker.Level * 2) / 5) +2;
        float resistance = attacker.ATK / target.DEF;
        int damage = Mathf.FloorToInt((levelMult * power * resistance) / 50 + 2);

        Debug.Log(attacker.name + " attacked for " + damage + " DMG!");
        return damage;
    }
}
