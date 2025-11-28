using System;
using UnityEngine;

[Serializable]
public struct Save
{
    public PlayerData _player;
    //public CharacterData[] _party; 
    
    public Save(PlayerData player)
    {
     
        this._player = player;   
    }
}

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

[Serializable]
public class CharacterData
{
    public int hp;
    public int sp;
    
    public CharacterData(int _hp, int _sp)
    {
        this.hp = _hp;
        this.sp = _sp;
    }
}