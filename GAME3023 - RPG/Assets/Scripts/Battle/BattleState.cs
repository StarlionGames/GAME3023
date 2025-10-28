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
        PartyMembers = GameManager.instance.partyManager.Party;
        HostileRoom.SendEnemy += GetEnemy;

        CurrentActiveCharacter = PartyMembers[0];

        CurrentActiveCharacter.CurrHP = CurrentActiveCharacter.MaxHP; // fully heal the enemy for testing purposes
        Enemy.CurrHP = Enemy.MaxHP; // fully heal the enemy for testing purposes
        Enemy.Resurrect();

        EnemyTurn += () => Enemy.AttackTarget(CurrentActiveCharacter);
    }
    private void OnDisable()
    {
        PartyMembers = null;
        HostileRoom.SendEnemy -= GetEnemy;
    }
    private void Start()
    {
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
        //EnemyTurn = null;
    }
}
