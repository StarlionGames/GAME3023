using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleState : MonoBehaviour
{
    List<Character> PartyMembers;

    public Character CurrentActiveCharacter;
    public Enemy Enemy;
    public BattlePhases CurrentPhase;
    public float TurnsSinceStart;

    private void OnEnable()
    {
        PartyMembers = GameManager.instance.partyManager.Party;
        CurrentActiveCharacter = PartyMembers[0];

        CurrentPhase = BattlePhases.PlayerTurn;
    }
    private void OnDisable()
    {
        PartyMembers = null;
    }
    public void PlayerTurn()
    {
        if (Enemy.IsDowned)
        {
            CurrentPhase = BattlePhases.Win;
            
        }
    }

}
