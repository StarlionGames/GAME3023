using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData(Player _player)
    {
        position = new float[3];

        Vector3 _pos = _player.transform.position;
        position[0] = _pos.x;
        position[1] = _pos.y;
        position[2] = _pos.z;
    }
}
