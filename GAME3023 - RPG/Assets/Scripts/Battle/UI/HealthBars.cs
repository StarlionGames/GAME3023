using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    Character character;
    [SerializeField] bool isEnemy;

    Slider slider => GetComponentInChildren<Slider>();

    private void OnEnable()
    {
        if (isEnemy)
        {
            HostileRoom.SendEnemy += GetEnemy;
        }
        else
        {
            character = GameManager.instance.partyManager.Party[0];
            OnBattleStarted();
        }
    }
    private void OnDisable()
    {
        if (isEnemy) { HostileRoom.SendEnemy -= GetEnemy; }
        if (character != null)
        {
            character.OnDamage -= UpdateSliderValue;
            character = null;
        }
    }
    void Start()
    {
        if (character == null) { Debug.Log("no assigned character on " + gameObject.name); }
        character.OnDamage += UpdateSliderValue;
    }
    void OnBattleStarted()
    {
        if (slider == null || character == null) { return; }
        
        slider.minValue = 0;
        slider.maxValue = character.MaxHP;
        slider.value = character.CurrHP;
    }
    void UpdateSliderValue()
    {
        if (slider == null || character == null) { return; }

        slider.value = character.CurrHP;
    }
    void GetEnemy(Enemy sentEnemy)
    {
        sentEnemy.BattleStart();
        character = sentEnemy;
        OnBattleStarted();
    }
}
