using UnityEngine;

public class PartyDatabase : MonoBehaviour
{
    public Party[] AllPlayableCharacters;

    public Party GetCharacterByID(int ID)
    {
        foreach (Party p in AllPlayableCharacters)
        {
            if (p.ID == ID) return p;
        }
        return null;
    }
}
