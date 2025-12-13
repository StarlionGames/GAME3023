using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public MapManager mapManager { get; private set; }
    public PartyManager partyManager { get; private set; }
    public SceneLoader sceneLoader { get; private set; }
    public AudioManager audioManager { get; private set; }
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
            audioManager = GetComponentInChildren<AudioManager>();

            SceneManager.LoadSceneAsync((int)SceneDirectory.StartScene, LoadSceneMode.Additive);
            audioManager.ChangeBGM(AudioDirectory.StartMusic);
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
        List<string> itemsObtained =  new List<string>(SaveSystem.CurrentSave._obtainedOverworldItems);

        Save SaveState = new Save(_player, _party, itemsObtained);
        
        SaveSystem.InitiateSave(SaveState);
    }
}
