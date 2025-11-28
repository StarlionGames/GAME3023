using UnityEngine;
using System.IO;
using System;
public static class SaveSystem
{
    public static Action<Save> OnSaveLoaded;
    private static string path = Path.Combine(Application.persistentDataPath, "player.json");

    public static void CreateNewSave()
    {
        Player newPlayer = new Player();
        PartyManager newManager = new PartyManager();

        PlayerData playerData = new PlayerData(newPlayer);
        PartyData partyData = new PartyData(newManager.Party.Count, newManager);

        Save newSave = new Save(playerData,partyData);
        InitiateSave(newSave);
    }

    #region Save Functions

    public static void InitiateSave(Save save)
    {
        PlayerData player_data = save._player;
        PartyData party_data = save._party;

        string json = JsonUtility.ToJson(player_data) + "\n" + JsonUtility.ToJson(party_data);

        try
        {
            File.WriteAllText(path, json);
            Debug.Log("data saved to: " + path);
        }
        catch { }
    }
    #endregion

    #region Load Functions
    public static Save LoadSave()
    {
        if (!File.Exists(path)) { Debug.Log("save file does not exist in " + path); return default; }

        try
        {
            string _json = File.ReadAllText(path);
            Save _data = JsonUtility.FromJson<Save>(_json);

            return _data;
        }
        catch { return default; }
    }
    #endregion
}
