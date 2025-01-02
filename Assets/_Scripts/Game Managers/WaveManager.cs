using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static event Action startNextWave;

    private void OnEnable() 
    { 
        EnemyDeathComponent.enemyDeath += CheckEnemyCount;
        WaveSpawner.enemySpawned += IncrementEnemyCount;
    }
    private void OnDisable() 
    { 
        EnemyDeathComponent.enemyDeath -= CheckEnemyCount;
        WaveSpawner.enemySpawned -= IncrementEnemyCount;
    }

    private int enemyCount;

    private void IncrementEnemyCount()
    {
        enemyCount++;
        Debug.Log($"Current enemy count: {enemyCount}");
    }

    private void CheckEnemyCount()
    {
        Debug.Log($"Enemy destroyed, current enemy count: {enemyCount}");
        enemyCount--;

        if (enemyCount <= 0)
        {
            Debug.Log("Starting next wave");
            startNextWave?.Invoke();
        }
    }
}
