using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    public PartyDatabase database;
    public List<Party> Party = new List<Party>();

    private void OnEnable()
    {
        SaveSystem.OnSaveLoaded += LoadParty;
    }
    private void OnDisable()
    {
        SaveSystem.OnSaveLoaded -= LoadParty;
    }

    public void LoadParty(Save save)
    {
        Party.Clear();
        CharacterData[] loadedParty = save._party;

        foreach (CharacterData c in loadedParty) 
        {
            Party.Add(LoadCharacter(c));
        }
    }

    Party LoadCharacter(CharacterData data)
    {
        Party character = database.GetCharacterByID(data.id);

        if (character == null) { return null; }

        character.Level = data.lvl;
        character.CurrHP = data.hp;
        character.CurrSP = data.sp;

        return character;
    }
}
