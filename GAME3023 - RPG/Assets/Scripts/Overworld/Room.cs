using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour, Initialize
{
    public List<SceneEntrance> allEntrance;

    public void Initialize()
    {
        GameManager.instance.mapManager.SetCurrentRoom(this);
    }

    private void Awake()
    {
        foreach(var entrance in FindObjectsByType<SceneEntrance>(FindObjectsSortMode.None))
        {
            allEntrance.Add(entrance);
        }
    }
}
