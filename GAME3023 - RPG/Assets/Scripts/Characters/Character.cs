using UnityEngine;
using System.Collections.Generic;

public class Character: MonoBehaviour
{
    public int Level;
    public bool IsDowned = false;

    [Header("HP / SP")]
    public int MaxHP;
    public int CurrHP;
    public int MaxSP;
    public int CurrSP;

    [Header("Stats")]
    public int ATK;
    public int DEF; // protection against physical
    public int RES; // protection against magic
    public int SPD;

    [Header("Skills")]
    public List<Skills> skills;

    [Header("Status Effects")]
    public List<StatusEffect> statusEffects;

    public delegate void CharacterAction();
    public CharacterAction Attack;
    public CharacterAction OnDeath;
    
    public void TakeDamage(int Damage)
    {
        CurrHP -= Damage;
        if (CurrHP > 0)
        {
            CurrHP = 0;
            OnDeath?.Invoke();
        }
    }
}
