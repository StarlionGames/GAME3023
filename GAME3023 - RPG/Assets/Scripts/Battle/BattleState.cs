using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleState : MonoBehaviour
{
    List<Character> PartyMembers;

    public Character CurrentActiveCharacter;
    public Enemy Enemy;
    public float TurnsSinceStart;

    private void Awake()
    {
        PartyMembers = GameManager.instance.partyManager.Party;
    }
    private void OnEnable()
    { 
        CurrentActiveCharacter = PartyMembers[0];
    }
    private void OnDisable()
    {
        PartyMembers = null;
    }
   
}
