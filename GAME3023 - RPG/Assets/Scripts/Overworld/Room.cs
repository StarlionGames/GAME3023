using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour, Initialize
{
    public List<SceneEntrance> allEntrance = new List<SceneEntrance>();
    public Collider2D cameraBounds;

    public void Initialize()
    {
        allEntrance.Clear();
        foreach (var entrance in FindObjectsByType<SceneEntrance>(FindObjectsSortMode.None))
        {
            allEntrance.Add(entrance);
        }

        GameManager.instance.mapManager.SetCurrentRoom(this);
    }

    private void Start()
    {
       Initialize();
    }

    public SceneEntrance GetEntranceByID(string id)
    {
        foreach(SceneEntrance e in allEntrance)
        {
            if (e.globalID.id == id) {  return e; }
        }
        
        return null;
    }
}
