using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Enemy")]
public class Enemy : Character
{
    public override void AttackTarget(Character target)
    {
        DamageCalculator.CalculateFlatDamage(this, target);
    }
}
