using UnityEngine;
using System.IO;
public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "player.json");

    public static void SavePlayer(Player _player)
    {
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
