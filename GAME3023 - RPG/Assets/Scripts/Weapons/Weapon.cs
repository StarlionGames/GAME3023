using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public int BaseAttack;
    public StatusEffect Effect;
}
