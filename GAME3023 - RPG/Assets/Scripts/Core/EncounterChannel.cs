using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/New Encounter Channel")]
public class EncounterChannel : ScriptableObject
{
    public Action<Enemy> OnEventRaised;
    public void RaiseEvent(Enemy value) { OnEventRaised?.Invoke(value); }
}
