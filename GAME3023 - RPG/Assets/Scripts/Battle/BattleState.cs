using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class BattleState : MonoBehaviour
{
    List<Party> PartyMembers;

    public Party CurrentActiveCharacter;
    public Enemy Enemy;
    public float TurnsSinceStart;

    public static Action PlayerTurn;
    public static Action EnemyTurn;
    
    private void OnDisable()
    {
        PartyMembers = null;
    }
    private void Start()
    {
        PartyMembers = GameManager.instance.partyManager.Party;
        CurrentActiveCharacter = PartyMembers[0];

        CurrentActiveCharacter.CurrHP = CurrentActiveCharacter.MaxHP; // fully heal the enemy for testing purposes
        Enemy.CurrHP = Enemy.MaxHP; // fully heal the enemy for testing purposes

    }
    public void EmptyTurnActions()
    {
        PlayerTurn = null;
        //EnemyTurn = null; 
        // leave out enemy turn nullification until different actions are implemented
    }
   
}
