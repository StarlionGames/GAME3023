using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public MapManager mapManager { get; private set; }
    public PartyManager partyManager { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);

            mapManager = GetComponentInChildren<MapManager>();
            partyManager = GetComponentInChildren<PartyManager>();
        }
    }
}
