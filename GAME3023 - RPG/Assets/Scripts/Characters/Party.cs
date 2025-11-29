using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Party Member")]
public class Party : Character
{
    public int ID;
    public Weapon EquippedWeapon;
    [SerializeField] List<Skills> PotentialSkillList;

    public override void AttackTarget(Character target)
    {
        int Damage = DamageCalculator.CalculateFlatDamage(this, target, EquippedWeapon.BaseAttack);
       
        target.TakeDamage(Damage);
    } 
    public void LevelUp()
    {
        if (PotentialSkillList.Count != 0) 
        {
            AddNewSkill(PotentialSkillList[0]);
            PotentialSkillList.RemoveAt(0);
        }
        else
        {
            Debug.Log("skill list is empty");
        }
    }
    public void AddNewSkill(Skills skillToAdd)
    {
        if (!skills.Contains(skillToAdd))
            skills.Add(skillToAdd);
        else Debug.Log("skill is already obtained!");
    }
}
