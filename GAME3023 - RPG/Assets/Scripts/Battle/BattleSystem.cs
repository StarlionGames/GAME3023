using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattlePhases
{
    BeginFight,
    PlayerTurn, 
    EnemyTurn,
    Win,
    Lose
}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public BattlePhases phases => state.CurrentPhase;

    public static Action OnTurnBegin;
    public static Action OnTurnEnd;
    public static Action UpdatePhases;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    public void SwitchTurns()
    {
        if (phases == BattlePhases.PlayerTurn)
        {
            state.CurrentPhase = BattlePhases.EnemyTurn; return;
        }
        if (phases == BattlePhases.EnemyTurn)
        {
            state.CurrentPhase = BattlePhases.PlayerTurn; return;
        }
    }
}
