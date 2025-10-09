using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(menuName = "Character/New Base Character")]
public class Character: ScriptableObject
{
    public int Level;
    public bool IsDowned = false;

    public int BaseHP => 150 + (Level * 10);
    
    [Header("Stats")]
    public int ATK;
    public int DEF; // protection against physical
    public int RES; // protection against magic
    public int SPD;

    public List<Skills> skills;
    public List<StatusEffect> statusEffects;

    public delegate void CharacterAction();
    public CharacterAction Attack;
    public CharacterAction OnDeath;
}
