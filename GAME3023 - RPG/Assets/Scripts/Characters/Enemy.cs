using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Enemy")]
public class Enemy : Character
{
    [Header("HP / SP")]
    public int MaxHP;
    public int MaxSP;
}
