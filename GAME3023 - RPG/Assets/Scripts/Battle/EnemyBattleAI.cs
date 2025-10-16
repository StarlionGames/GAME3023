using UnityEngine;

public class EnemyBattleAI : MonoBehaviour
{
    Enemy enemy => BattleSystem.instance.state.Enemy;
    private void Start()
    {
        PickAction();
    }
    public void PickAction()
    {
        // default action for now
        // enable the ability to pick the target later
        BattleState.EnemyTurn = () => enemy.AttackTarget(BattleSystem.instance.state.CurrentActiveCharacter);
    }
}
