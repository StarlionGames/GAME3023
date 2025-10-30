using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    Character character;
    [SerializeField] bool isEnemy;

    Slider slider;

    private void OnEnable()
    {
        if (isEnemy)
        {
            HostileRoom.SendEnemy += GetEnemy;
        }
        else
        {
            character = GameManager.instance.partyManager.Party[0];
        }
    }
    private void OnDisable()
    {
        if (isEnemy)
        {
            HostileRoom.SendEnemy -= GetEnemy;
        }
        else { 
            character = null;
        }
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        
        slider.minValue = 0;
        slider.maxValue = character.MaxHP;
        slider.value = character.CurrHP;

        character.OnDamage += UpdateSliderValue;
    }
    void UpdateSliderValue()
    {
        slider.value = character.CurrHP;
    }
    void GetEnemy(Enemy sentEnemy) => character = sentEnemy;
}
