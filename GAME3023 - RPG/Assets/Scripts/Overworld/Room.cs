using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [SerializeField] float roomEncounterRate;

    public float GetEncounterRate() { return roomEncounterRate; }
}
