using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WaveState
{
    Cooldown,
    Active
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField]
    private int enemiesToAdd = 2;
    [SerializeField]
    private int baseEnemyCount = 5;
    [SerializeField]
    private float spawnDelay = 0.15f;
    [SerializeField]
    private CircleCollider2D spawningCircle;

    [Header("Enemy To Spawn")]
    [SerializeField]
    private GameObject enemyPrefab;

    public static event Action<int> currentWave;
    public static event Action enemySpawned;

    private int waveCount = 1;
    private WaveState currentWaveState;
    private float spawnRadius;

    #region Wave Spawner

    private void OnEnable()
    {
        WaveManager.startNextWave += SpawnNextWave;
    }

    private void OnDisable()
    {
        WaveManager.startNextWave -= SpawnNextWave;
    }

    private void Awake()
    {
        spawnRadius = spawningCircle.radius;
    }

    private void Start()
    {
        StartCoroutine(SpawnWave(waveCount));
    }

    private void SpawnNextWave()
    {
        currentWaveState = WaveState.Cooldown;
        StartCoroutine(SpawnWave(waveCount));
    }

    private IEnumerator SpawnWave(int currentWaveNumber)
    {
        currentWaveState = WaveState.Active;
        currentWave?.Invoke(currentWaveNumber);

        int enemiesToSpawn = WaveEnemyCount(currentWaveNumber);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var spawnPoint = RandomPointAtCircleEdge(spawnRadius);

            Instantiate(enemyPrefab, spawnPoint + transform.position, Quaternion.identity);

            enemySpawned?.Invoke();

            yield return new WaitForSeconds(spawnDelay);
        }

        waveCount++;
    }

    private Vector3 RandomPointAtCircleEdge(float radius)
    {
        Vector3 spawnDirection = Random.insideUnitSphere;
        spawnDirection.z = 0.0f;

        spawnDirection.Normalize();

        var spawnPoint = spawnDirection * radius;

        return new Vector3(spawnPoint.x, spawnPoint.y, 0.0f);
    }

    private int WaveEnemyCount(int waveCount)
    {
        return baseEnemyCount + (enemiesToAdd * waveCount);
    }

    #endregion

    #region Debug

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    #endregion
}
