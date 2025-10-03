using System;
using UnityEngine;

public class TallGrass : MonoBehaviour
{
    public static event Action SteppedOnEncounterTile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SteppedOnEncounterTile?.Invoke();
        }
    }
}
