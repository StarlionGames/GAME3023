using UnityEngine;
using System.IO;
public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "player.json");

    public static void CreateNewSave()
    {
        Player newPlayer = new Player();
        PartyManager newManager = new PartyManager();

        InitiateSave(newPlayer, newManager);
    }

    #region Save Functions

    public static void InitiateSave(Player _player, PartyManager _manager)
    {
        PlayerData player_data = new PlayerData(_player);
        PartyData party_data = new PartyData(_manager.Party.Count, _manager);

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
    public static PlayerData LoadSave()
    {
        if (!File.Exists(path)) { Debug.Log("save file does not exist in " + path); return null; }

        try
        {
            string _json = File.ReadAllText(path);
            PlayerData _data = JsonUtility.FromJson<PlayerData>(_json);

            return _data;
        }
        catch { return null; }
    }
    #endregion
}
