using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public MapManager mapManager { get; private set; }
    public PartyManager partyManager { get; private set; }
    public SceneLoader sceneLoader { get; private set; }
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
            sceneLoader = GetComponentInChildren<SceneLoader>();

            SceneManager.LoadSceneAsync((int)SceneDirectory.StartScene, LoadSceneMode.Additive);
        }
    }

    public void SaveGame()
    {  
        PlayerData _player = new PlayerData(Player.Instance);
        CharacterData[] _party = new CharacterData[]
        {
            new CharacterData(partyManager.Party[0]),
            new CharacterData(partyManager.Party[1]),
            new CharacterData(partyManager.Party[2])
        };

        Save SaveState = new Save(_player, _party);
        
        SaveSystem.InitiateSave(SaveState);
    }
}
