using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    Room currRoom;

    [SerializeField] float CurrEncounterRate = 10;
    [SerializeField] float DistanceMulti = 1;

    [SerializeField] int SafetyDistRemaining = 10;

    private void OnEnable()
    {
        currRoom = GetComponent<Room>();
        TallGrass.SteppedOnEncounterTile += GrassDeterminer;
    }
    private void OnDisable()
    {
        TallGrass.SteppedOnEncounterTile -= GrassDeterminer;
    }
    public void GrassDeterminer()
    {
        if (SafetyDistRemaining > 0) { SafetyDistRemaining--; }
        else { RollEncounter(); }
    }
    public void RollEncounter()
    {
        int point = UnityEngine.Random.Range(1, 100);

        if (point <= CurrEncounterRate) 
        { 
            ResetEncounterRate();
            Debug.Log("encounter!");
            SceneManager.LoadScene("BattleScene");
        } // add encountering thing and encounter rate resetting
        else
        {
            DistanceMulti += 0.05f;
            CurrEncounterRate = (CurrEncounterRate * DistanceMulti) + currRoom.GetEncounterRate();
            Debug.Log("stepped in tall grass");
        }
    }
    public void ResetEncounterRate()
    {
        CurrEncounterRate = 10;
        DistanceMulti = 1;
    }
}
