using UnityEngine;
using System.IO;
public static class SaveSystem
{
    public static void SavePlayer(Player _player)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.json");

        PlayerData data = new PlayerData(_player);
        string _json = JsonUtility.ToJson(data);

        try
        {
            File.WriteAllText(path, _json);
            Debug.Log("player saved to: " + path);
        }
        catch { }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.json");
        if (!File.Exists(path)) { Debug.Log("save file does not exist in " + path); return null; }

        try
        {
            string _json = File.ReadAllText(path);
            PlayerData _data = JsonUtility.FromJson<PlayerData>(_json);

            return _data;
        }
        catch { return null; }
    }
}
