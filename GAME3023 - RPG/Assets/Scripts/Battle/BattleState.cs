using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class BattleState : MonoBehaviour
{
    [SerializeField] EncounterManager _encounterManager;
    [SerializeField] EncounterChannel _encounterChannel;
    List<Party> PartyMembers;

    public Party CurrentActiveCharacter;
    public Enemy Enemy;
    public float TurnsSinceStart;

    public static event Action PlayerTurn;
    public static event Action EnemyTurn;
    public static event Action<BattleState> OnBattleStateAwake;

    private void OnEnable()
    {
        Enemy = _encounterManager.GetEnemies();
        
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
        _encounterChannel.OnEventRaised(Enemy);
        OnBattleStateAwake?.Invoke(this);
    }
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
