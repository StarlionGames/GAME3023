using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public PlayerData _player;
    public CharacterData[] _party; 
    public List<string> _obtainedOverworldItems;
    
    public Save(PlayerData player, CharacterData[] party, List<string> items)
    {
        this._player = player;   
        this._party = party;
        this._obtainedOverworldItems = new List<string>();
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
    public int id;
    public int lvl;
    public int hp;
    public int sp;
    
    public CharacterData(Party character)
    {
        this.id = character.ID;
        this.lvl = character.Level;
        this.hp = character.CurrHP;
        this.sp = character.CurrSP;
    }
}