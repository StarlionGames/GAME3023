using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattlePhases
{
    BeginFight,
    SetUp,
    PlayerTurn, 
    EnemyTurn,
    Win,
    Lose
}

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance { get; private set; }
    
    public BattleState state;
    [SerializeField] BattleSceneUI ui;
    public BattlePhases CurrentPhase;

    public static Action OnTurnBegin;
    public static Action OnTurnEnd;
    public static Action UpdatePhases;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else { instance = this; }
    }
    private void Start()
    {
        OnTurnBegin += () => StartCoroutine(Battle());
        OnTurnEnd += state.EmptyTurnActions;
        OnTurnEnd += ChooseActions;
        
        CurrentPhase = BattlePhases.BeginFight;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        ui.UpdateText("A " + state.Enemy.name + " appeared!");

        yield return new WaitForSeconds(1.5f);

        ChooseActions();
    }
    IEnumerator Battle()
    {
        CurrentPhase = BattlePhases.PlayerTurn;
        BattleState.PlayerTurn?.Invoke();
        if (state.Enemy.IsDowned) yield break;

        yield return new WaitForSeconds(1.5f);

        CurrentPhase = BattlePhases.EnemyTurn;
        ui.UpdateText("enemy attacked!");
        BattleState.EnemyTurn?.Invoke();
        yield return new WaitForSeconds(1.5f);

        OnTurnEnd?.Invoke();
        yield break;
    }
    public void ChooseActions()
    {
        ui.ClearCanvas();
        CurrentPhase = BattlePhases.SetUp;
        ui.ShowPlayerActions();
    }
}
