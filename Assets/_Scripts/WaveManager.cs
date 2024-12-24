using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static event Action startNextWave;

    private void OnEnable() 
    { 
        EnemyScript.enemyDeath += CheckEnemyCount;
        WaveSpawner.waveSpawned += CacheEnemies;
    }
    private void OnDisable() 
    { 
        EnemyScript.enemyDeath -= CheckEnemyCount;
        WaveSpawner.waveSpawned -= CacheEnemies;
    }

    private int enemyCount;

    private void CacheEnemies(int incomingEnemyCount)
    {
        enemyCount = incomingEnemyCount;
        Debug.Log($"Current Enemy Count: ${enemyCount}");
    }

    private void CheckEnemyCount()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            startNextWave?.Invoke();
        }
    }
}
