using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Character/New Base Character")]
public class Character: ScriptableObject
{
    public Sprite sprite;
    public int Level;
    public bool IsDowned = false;

    [Header("HP / SP")]
    public int MaxHP => 150 + (Level * 10);
    public int MaxSP => 10 + (Level * 5);

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
    public CharacterAction TurnAction;
    public CharacterAction OnDeath;

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
    public void TakeDamage(int damage)
    {
        CurrHP -= damage;
        if (CurrHP < 0)
        {
            CurrHP = 0;
            OnDeath?.Invoke();
        }
    }
    public void HasBeenDowned()
    {
        IsDowned = true;
    }
}
