using UnityEngine;
using System.Collections.Generic;

public class Character: MonoBehaviour
{
    public string Name;
    public int Level;

    [Header("HP / SP")]
    public float MaxHP;
    public float CurrHP;
    public float MaxSP;
    public float CurrSP;

    [Header("Stats")]
    public float ATK;
    public float DEF; // protection against physical
    public float RES; // protection against magic
    public float SPD;

    public Skills[] skills = new Skills[4];
    public List<StatusEffect> statusEffects = new List<StatusEffect>();

}
