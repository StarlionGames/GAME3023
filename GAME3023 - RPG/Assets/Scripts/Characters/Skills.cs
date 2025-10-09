using UnityEngine;

[CreateAssetMenu(menuName = "New Skill")]
public class Skills : ScriptableObject
{
    public int BaseDamage;
    public int SPNeeded;
    public StatusEffect effectApplied;
}
