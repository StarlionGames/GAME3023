using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Enemy")]
public class Enemy : Character
{
    public override void AttackTarget(Character target)
    {
        int damage = DamageCalculator.CalculateFlatDamage(this, target, 40);
        target.TakeDamage(damage);
    }
    public void BattleStart()
    {
        CurrHP = MaxHP;
        CurrSP = MaxSP;

        Resurrect();
    }
}
