using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    Room currRoom;

    public void SetCurrentRoom(Room roomToSet)
    {
        currRoom = roomToSet;
    }
}
