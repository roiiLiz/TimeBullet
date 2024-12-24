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
        WaveSpawner.enemySpawned += IncrementEnemyCount;
    }
    private void OnDisable() 
    { 
        EnemyScript.enemyDeath -= CheckEnemyCount;
        WaveSpawner.enemySpawned -= IncrementEnemyCount;
    }

    private int enemyCount;

    private void IncrementEnemyCount()
    {
        enemyCount++;
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
