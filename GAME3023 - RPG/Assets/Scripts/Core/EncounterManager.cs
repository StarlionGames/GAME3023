using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncounterManager", menuName = "Scriptable Objects/New EncounterManager")]
public class EncounterManager : ScriptableObject
{
    public Enemy _enemies;

    public void SetEnemies(Enemy enemies)
    {
        _enemies = enemies;
    }
    public Enemy GetEnemies()
    {
        if (_enemies == null) { return null; } return _enemies;
    }
}
