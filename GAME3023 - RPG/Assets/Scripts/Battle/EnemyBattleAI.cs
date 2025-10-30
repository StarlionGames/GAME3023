using UnityEngine;

public class EnemyBattleAI : MonoBehaviour
{
    BattleState battleState;
    BattleSceneUI ui;
    
    Enemy enemy => battleState.Enemy;

    private void OnEnable()
    {
        BattleState.OnBattleStateAwake += GetBattleState;
        BattleSceneUI.OnBattleUIAwake += GetBattleUI;
        BattleSystem.OnTurnEnd += PickAction;
    }
    private void Start()
    {
        
    }

    void GetBattleState(BattleState currBattleState) => battleState = currBattleState;
    void GetBattleUI(BattleSceneUI currUI) => ui = currUI;

    public void PickAction()
    {
        if (battleState == null || ui == null || enemy == null) return;
        
        // if enemy hp is lower than half, start using more powerful moves
        if (enemy.CurrHP > (enemy.MaxHP / 2))
        {
            BattleState.EnemyTurn += () => ui.UpdateText(enemy.name + " attacked!");
            BattleState.EnemyTurn += () => enemy.AttackTarget(battleState.CurrentActiveCharacter);
        }
        else
        {
            Skills skill = enemy.skills[Random.Range(0, enemy.skills.Count - 1)];

            BattleState.EnemyTurn += () => ui.UpdateText(enemy.name + " used the skill " + skill.name + "!");
            BattleState.EnemyTurn += () => enemy.UseSkill(skill, battleState.CurrentActiveCharacter);
        }
    }
}
