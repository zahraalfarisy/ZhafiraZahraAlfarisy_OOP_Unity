using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy enemyPrefab;  // Drag your Enemy prefab here in Inspector

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;

    [SerializeField] private float spawnInterval = 3f;
    private float spawnTimer = 0;

    [Header("Spawned Enemy Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    void Update()
    {
        if (!isSpawning) return;

        // Update spawn timer
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemies();  // Pindahkan logika spawn ke metode terpisah
            spawnTimer = 0;  // Reset timer after spawning
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);  // Spawn enemy at spawner's position
    }

    public void RegisterKill()
    {
        totalKill++;
        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            totalKill = 0;  // Reset kill count
            spawnCount += multiplierIncreaseCount;  // Increase spawn count
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
