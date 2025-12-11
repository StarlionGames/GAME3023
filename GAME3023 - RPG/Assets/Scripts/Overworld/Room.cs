using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    public List<SceneEntrance> allEntrance;

    private void Awake()
    {
        foreach(var entrance in FindObjectsByType<SceneEntrance>(FindObjectsSortMode.None))
        {
            allEntrance.Add(entrance);
        }
    }
}
