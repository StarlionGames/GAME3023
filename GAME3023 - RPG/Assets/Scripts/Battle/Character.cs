using UnityEngine;

public class Character: MonoBehaviour
{
    public string Name;
    public int Level;
    public float MaxHP;
    public float CurrHP;
    public Skills[] skills = new Skills[4];
}
