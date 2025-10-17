using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    [SerializeField] Character character;

    Slider slider => GetComponent<Slider>();

    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = character.MaxHP;
        slider.value = character.CurrHP;

        character.OnDamage += UpdateSliderValue;
    }
    void UpdateSliderValue()
    {
        slider.value = character.CurrHP;
    }
}
