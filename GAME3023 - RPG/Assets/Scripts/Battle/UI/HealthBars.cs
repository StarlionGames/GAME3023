using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    [Header("Channels")]
    [SerializeField] EncounterChannel _encounterChannel;
    
    Character character;
    [SerializeField] bool isEnemy;

    Slider slider => GetComponentInChildren<Slider>();

    private void OnEnable()
    {
        if (isEnemy)
        {
            _encounterChannel.OnEventRaised += GetEnemy;
        }
        else
        {
            character = GameManager.instance.partyManager.Party[0];
            OnBattleStarted();
        }
    }
    private void OnDisable()
    {
        if (isEnemy) { _encounterChannel.OnEventRaised -= GetEnemy; }
        if (character != null)
        {
            character.OnDamage -= UpdateSliderValue;
            character = null;
        }
    }
    void OnBattleStarted()
    {
        if (slider == null || character == null) { Debug.Log("no assigned character on " + gameObject.name); return; }
        
        slider.minValue = 0;
        slider.maxValue = character.MaxHP;
        slider.value = character.CurrHP;

        character.OnDamage += UpdateSliderValue;
    }
    void UpdateSliderValue()
    {
        if (slider == null || character == null) { Debug.Log("no assigned character on " + gameObject.name); return; }

        slider.value = character.CurrHP;
    }
    void GetEnemy(Enemy sentEnemy)
    {
        sentEnemy.BattleStart();
        character = sentEnemy;
        OnBattleStarted();
    }
}
