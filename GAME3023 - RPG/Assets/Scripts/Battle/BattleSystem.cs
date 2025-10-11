using System;
using System.Collections;
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
    [SerializeField] BattleState state;
    [SerializeField] BattleSceneUI ui;
    public BattlePhases CurrentPhase;

    public static Action OnTurnBegin;
    public static Action OnTurnEnd;
    public static Action UpdatePhases;

    private void Start()
    {
        CurrentPhase = BattlePhases.BeginFight;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        ui.UpdateText("A " + state.Enemy.name + " appeared!");

        yield return new WaitForSeconds(2f);

        ui.ClearCanvas();
        CurrentPhase = BattlePhases.PlayerTurn;
        ui.ShowPlayerActions();
    }
    public void SwitchTurns()
    {
        if (CurrentPhase == BattlePhases.PlayerTurn)
        {
            CurrentPhase = BattlePhases.EnemyTurn; return;
        }
        if (CurrentPhase == BattlePhases.EnemyTurn)
        {
            CurrentPhase = BattlePhases.PlayerTurn; return;
        }
    }
}
