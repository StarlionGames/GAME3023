using UnityEngine;

[CreateAssetMenu(menuName = "Skills/New Base Skill")]
public class Skills : ScriptableObject
{
    public string skillName => this.name;
    public string Description;

    public int BasePower; // how strong the ability is
    public int SPNeeded;

    public virtual void UseSkill(Character caster, Character target) { }
}
