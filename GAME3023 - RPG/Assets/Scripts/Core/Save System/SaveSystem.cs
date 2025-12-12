using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
public static class SaveSystem
{
    public static Action<Save> OnSaveLoaded;
    public static Save CurrentSave;
    private static string path = Path.Combine(Application.persistentDataPath, "player.json");

    public static void CreateNewSave()
    {
        Player newPlayer = new Player();

        PlayerData playerData = new PlayerData(newPlayer);
        CharacterData[] characters = new CharacterData[] { };
        List<string> items = new List<string>();

        CurrentSave = new Save(playerData, characters, items);
        InitiateSave(CurrentSave);
    }

    #region Save Functions

    public static void InitiateSave(Save save)
    {
        CurrentSave = save;
        string json = JsonUtility.ToJson(save);

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

            CurrentSave = _data;
            OnSaveLoaded?.Invoke(_data);

            return _data;
        }
        catch { return default; }
    }

    #endregion
}
