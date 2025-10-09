using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    [SerializeField] BattleState state; 
    
    public void UpdateUI()
    {
        
    }
    public void TryToFlee()
    {
        // add probability stuff later

        SceneManager.LoadScene("TestingScene");
    }

    public void Attack()
    {
        if (state.CurrentPhase != BattlePhases.PlayerTurn) { return; }

        state.CurrentActiveCharacter.AttackTarget(state.Enemy);
        Debug.Log("you hit " +state.Enemy.name);
    }
}
