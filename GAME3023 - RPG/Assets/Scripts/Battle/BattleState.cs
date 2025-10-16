using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BattleState : MonoBehaviour
{
    List<Party> PartyMembers;

    public Party CurrentActiveCharacter;
    public Enemy Enemy;
    public float TurnsSinceStart;

    public static event Action PlayerTurn;
    public static event Action EnemyTurn;
    
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
        Enemy.Resurrect();

        EnemyTurn += () => Enemy.AttackTarget(BattleSystem.instance.state.CurrentActiveCharacter);
    }
    public void LaunchPlayerAction()
    {
        PlayerTurn?.Invoke();
        PlayerTurn = null;
    }
    public void LaunchEnemyAction()
    {
        EnemyTurn?.Invoke();
        //EnemyTurn = null;
    }
}
