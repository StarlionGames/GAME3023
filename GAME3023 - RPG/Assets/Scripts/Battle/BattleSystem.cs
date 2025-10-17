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
    [SerializeField] BattleState state;
    [SerializeField] BattleSceneUI ui;
    public BattlePhases CurrentPhase;

    public static Action OnTurnBegin;
    public static Action OnTurnEnd;
    public static Action UpdatePhases;
    public static Action<BattleSystem> OnBattleSystemAwake;

    private void OnEnable()
    {
        OnTurnBegin += () => StartCoroutine(Battle());
        OnTurnEnd += ChooseActions;

        CurrentPhase = BattlePhases.BeginFight;
        StartCoroutine(SetupBattle());
    }
    private void OnDisable()
    {
        OnTurnBegin -= () => StartCoroutine(Battle());
        OnTurnEnd -= ChooseActions;
    }
    private void Start()
    {
        OnBattleSystemAwake?.Invoke(this);
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
        state.LaunchPlayerAction();
        if (state.Enemy.IsDowned)
        {
            ui.UpdateText("you won!");
            yield return new WaitForSeconds(1.5f);
            BattleDeterminer(BattlePhases.Win);
            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("TestingScene");
        }
            

        yield return new WaitForSeconds(1.5f);

        CurrentPhase = BattlePhases.EnemyTurn;
        ui.UpdateText("enemy attacked!");
        state.LaunchEnemyAction();
        if (state.CurrentActiveCharacter.IsDowned)
        {
            ui.UpdateText("you lost...");
            BattleDeterminer(BattlePhases.Lose);
            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("TestingScene");
        }

        yield return new WaitForSeconds(1.5f);

        OnTurnEnd?.Invoke();
        yield break;
    }
    void BattleDeterminer(BattlePhases phase)
    {
        switch (phase)
        {
            case BattlePhases.Win:
                state.CurrentActiveCharacter.LevelUp();
                ui.UpdateText(state.CurrentActiveCharacter.name + " got the new skill " +
                    state.CurrentActiveCharacter.skills.FindLast(i => i).skillName + "!");
                break;
            case BattlePhases.Lose:
                
                break;
            default:
                break;
        }
    }
    public void ChooseActions()
    {
        ui.ClearCanvas();
        CurrentPhase = BattlePhases.SetUp;
        ui.ShowPlayerActions();
    }
}
