using UnityEngine;
using System.Collections.Generic;

public class BattleState : MonoBehaviour
{
    List<Character> PartyMembers => GameManager.instance.partyManager.Party;

    public Party CurrentActiveCharacter;
    public Enemy Enemy;
    public BattlePhases CurrentPhase;
    public float TurnsSinceStart;

    private void OnEnable()
    {
        
    }
    public void PlayerTurn()
    {
        if (Enemy.IsDowned)
        {
            CurrentPhase = BattlePhases.Win;
            
        }
    }

}
