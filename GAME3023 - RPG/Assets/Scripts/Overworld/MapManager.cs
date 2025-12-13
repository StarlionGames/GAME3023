using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public Room currRoom { get; private set; }

    public void SetCurrentRoom(Room roomToSet)
    {
        currRoom = roomToSet;
    }

    public void TeleportPlayer(Destination destination)
    {
        Scene thisScene = currRoom.gameObject.scene;
        int index = thisScene.buildIndex;

        StartCoroutine(GameManager.instance.sceneLoader.
            CrossFadeToOverworldScene(index, destination.sceneLocation, () =>
            {
                MovePlayer(destination, currRoom);
            }));   
        // TODO: turn the player's location to the destination id's location
    }

    public void MovePlayer(Destination destination, Room room)
    {
        SceneEntrance teleport = room.GetEntranceByID(destination.entranceID);
        if (teleport == null) { Debug.Log("teleport is missing"); return; }
        Player player = Player.Instance;
        player.transform.SetPositionAndRotation(teleport.position, teleport.rotation);
    }
}
