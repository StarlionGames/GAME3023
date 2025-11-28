using System;
using UnityEngine;

[Serializable]
public struct Save
{
    public PlayerData _player;
    public PartyData _party;
    
    public Save(PlayerData player, PartyData party)
    {
        _party = party;
        _player = player;   
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
public class PartyData
{
    public Party[] characters;

    public PartyData(int number, PartyManager _party)
    {
        characters = new Party[number];

        for (int i = 0; i < _party.Party.Count-1; i++)
        {
            characters[i] = _party.Party[i];
        }
    }
}