using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Party Member")]
public class Party : Character
{
    public Weapon EquippedWeapon;
   
    public override void AttackTarget(Character target)
    {
        int Damage = DamageCalculator.CalculateFlatDamage(this, target, EquippedWeapon.BaseAttack);
       
        target.TakeDamage(Damage);
    } 
    public void AddNewSkill(Skills skillToAdd)
    {
        skills.Add(skillToAdd);
    }
}
