using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileRoom : Room
{
    Vector3 PlayerPos => Player.Instance.gameObject.transform.position;
    Vector3 PrevPos;

    public float TotalDistanceWalked = 0;
    float EncounterTriggerThreshold = 10;
    
    [SerializeField] float RoomEncounterRate; // is the base encounter rate for the room
    [SerializeField] float SafetyDistRemaining = 10;

    [SerializeField, Range(0,100)] float EncounterRate;
    [SerializeField] float EncounterAdd;

    [SerializeField] List<Enemy> EnemyPool; // to get the pool of enemies in this room
    public static Action<Enemy> SendEnemy;

    private void OnEnable()
    {
        TallGrass.SteppedOnEncounterTile += IncreaseEncounterChance;
        GameManager.instance.mapManager.SetCurrentRoom(this);
    }
    private void OnDisable()
    {
        TallGrass.SteppedOnEncounterTile -= IncreaseEncounterChance;
    }

    public void IncreaseEncounterChance()
    {
        float distSoFar = CalculateDistance();

        if (SafetyDistRemaining > 0) { return; }

        EncounterTriggerThreshold -= distSoFar;

        if (EncounterTriggerThreshold < 0)
        {
            EncounterTriggerThreshold = UnityEngine.Random.Range(10,15);
            RollEncounter();
        }
    }
    public float CalculateDistance()
    {
        Vector3 CurrPos = PlayerPos;

        float distMoved = Vector3.Distance(CurrPos, PrevPos);
        if (SafetyDistRemaining > 0) { SafetyDistRemaining -= distMoved; }
        else { TotalDistanceWalked += distMoved; }

        PrevPos = CurrPos;
        return distMoved;
    }
    public void RollEncounter()
    {
        int point = UnityEngine.Random.Range(1, 100);

        if (point <= EncounterRate)
        {
            Debug.Log($"encounter rate was {EncounterRate} and the random was {point}.");
            ResetEncounters();
            LoadBattleScene("BattleScene", GetRandomEnemyFromPool());
        }
        else
        {
            float distMultiplier = TotalDistanceWalked / 100f;

            EncounterRate += EncounterAdd + distMultiplier;
            EncounterRate = Mathf.Clamp(EncounterRate, 0, 100);
        }
    }
    void ResetEncounters()
    {
        TotalDistanceWalked = 0;
        
        EncounterRate = RoomEncounterRate;
        EncounterAdd = 5;
    }
    Enemy GetRandomEnemyFromPool()
    {
        if (EnemyPool == null || EnemyPool.Count < 0) { return null; }

        Enemy chosenEnemy = EnemyPool[UnityEngine.Random.Range(0, EnemyPool.Count-1)];

        return chosenEnemy;
    }
    public static void LoadBattleScene(string sceneName, Enemy enemy)
    {
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SendEnemy?.Invoke(enemy);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }
    public float GetRoomEncounterRate() {  return RoomEncounterRate; }
}
