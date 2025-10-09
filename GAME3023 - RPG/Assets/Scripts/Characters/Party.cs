using UnityEngine;

[CreateAssetMenu(menuName = "Character/New Party Member")]
public class Party : Character
{
    [Header("HP / SP")]
    public int MaxHP => BaseHP + (Level * 5);
    public int BaseSP => 15 + (Level * 5);
    public int MaxSP => BaseSP + (Level * 5);

    public int CurrHP;
    public int CurrSP;

    public Weapon EquippedWeapon;
}
