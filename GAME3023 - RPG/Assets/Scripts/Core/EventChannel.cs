using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/New Event Channel")]
public class EventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;
    public void RaiseEvent() { OnEventRaised?.Invoke(); }
}
