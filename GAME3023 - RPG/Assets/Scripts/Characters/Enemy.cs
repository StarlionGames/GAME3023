using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Enemy")]
public class Enemy : Character
{
    [Header("HP")]
    public int MaxHP => BaseHP + (Level * 5);
    public int CurrHP;
}
