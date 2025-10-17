using UnityEngine;

public class EnemyBattleAI : MonoBehaviour
{
    BattleState battleState;
    Enemy enemy => battleState.Enemy;
    private void Start()
    {
        BattleState.OnBattleStateAwake += GetBattleState;
        //PickAction();
    }

    void GetBattleState(BattleState currBattleState) => battleState = currBattleState;

    public void PickAction()
    {
        if (battleState == null) return;
        // default action for now
        // enable the ability to pick the target later
        BattleState.EnemyTurn += () => enemy.AttackTarget(battleState.CurrentActiveCharacter);
    }
}
