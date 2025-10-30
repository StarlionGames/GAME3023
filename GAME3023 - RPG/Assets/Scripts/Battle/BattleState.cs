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
    public static event Action<BattleState> OnBattleStateAwake;

    private void OnEnable()
    {
        HostileRoom.SendEnemy += GetEnemy;
        PartyMembers = GameManager.instance.partyManager.Party;
        CurrentActiveCharacter = PartyMembers[0];      
    }
    private void OnDisable()
    {
        PartyMembers = null;
        PlayerTurn = null;
        EnemyTurn = null;
        OnBattleStateAwake = null;
    }
    private void Start()
    {
        CurrentActiveCharacter.CurrHP = CurrentActiveCharacter.MaxHP; // fully heal the enemy for testing purposes
        Enemy.CurrHP = Enemy.MaxHP; // fully heal the enemy for testing purposes
        Enemy.Resurrect();

        OnBattleStateAwake?.Invoke(this);
    }

    void GetEnemy(Enemy sentEnemy) => Enemy = sentEnemy;
    public void LaunchPlayerAction()
    {
        PlayerTurn?.Invoke();
        PlayerTurn = null;
    }
    public void LaunchEnemyAction()
    {
        EnemyTurn?.Invoke();
        EnemyTurn = null;
    }
}
