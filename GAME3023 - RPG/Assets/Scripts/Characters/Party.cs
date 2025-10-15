using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Party Member")]
public class Party : Character
{
    public Weapon EquippedWeapon;
   
    public override void AttackTarget(Character target)
    {
        int BaseDamage = DamageCalculator.CalculateFlatDamage(this, target);
        int FinalDamage = BaseDamage + EquippedWeapon.BaseAttack;

        target.TakeDamage(FinalDamage);
    } 
    public void AddNewSkill(Skills skillToAdd)
    {
        skills.Add(skillToAdd);
    }
}
