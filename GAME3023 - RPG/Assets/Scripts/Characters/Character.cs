using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Character/New Base Character")]
public class Character: ScriptableObject
{
    public Sprite sprite;
    public int Level;
    public bool IsDowned = false;

    [Header("HP / SP")]
    public int MaxHP;
    public int MaxSP;

    public int CurrHP;
    public int CurrSP;
    
    [Header("Stats")]
    public int ATK;
    public int DEF; // protection against physical
    public int RES; // protection against magic
    public int SPD;

    public List<Skills> skills;
    public List<StatusEffect> statusEffects;

    public delegate void CharacterAction();
    public CharacterAction OnDeath;
    public CharacterAction OnDamage;

    private void OnEnable()
    {
        CurrHP = MaxHP;
        CurrSP = MaxSP;
        
        OnDeath += HasBeenDowned;
    }
    private void OnDisable()
    {
        OnDeath -= HasBeenDowned;
    }
    public virtual void AttackTarget(Character target) { }
    public void UseSkill(Skills skill, Character target)
    {
        skill.UseSkill(this, target);
    }
    public void TakeDamage(int damage)
    {
        CurrHP -= damage;
        OnDamage?.Invoke();
        if (CurrHP < 0)
        {
            CurrHP = 0;
            OnDeath?.Invoke();
        }
    }
    public void HealHealth(int amount)
    {
        CurrHP += amount;
        if (CurrHP > MaxHP) { CurrHP = MaxHP; }
    }
    public void HasBeenDowned()
    {
        IsDowned = true;
    }
}
