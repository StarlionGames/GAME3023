using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleState : MonoBehaviour
{
    List<Character> PartyMembers;

    public Character CurrentActiveCharacter;
    public Enemy Enemy;
    public float TurnsSinceStart;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        PartyMembers = null;
    }
    private void Start()
    {
        PartyMembers = GameManager.instance.partyManager.Party;
        CurrentActiveCharacter = PartyMembers[0];
    }
    
   
}
