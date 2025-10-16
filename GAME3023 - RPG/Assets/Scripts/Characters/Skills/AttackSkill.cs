using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Attack Skill")]
public class AttackSkill : Skills
{
    public override void UseSkill(Character caster, Character target)
    {
        int dmg = DamageCalculator.CalculateFlatDamage(caster, target, BasePower);
        target.TakeDamage(dmg);
    }
}
