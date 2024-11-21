using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;  // Array of all EnemySpawners
    public float timer = 0;  // Timer to track the interval between waves
    [SerializeField] private float waveInterval = 5f;  // Interval in seconds between waves
    public int waveNumber = 1;  // Current wave number
    public int totalEnemies = 0;  // Total number of enemies spawned

    private void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Check if the timer exceeds the wave interval
        if (timer >= waveInterval)
        {
            // Start a new wave
            StartWave();
            // Reset the timer
            timer = 0;
        }
    }

    private void StartWave()
    {
        Debug.Log("Starting wave " + waveNumber);
        foreach (var spawner in enemySpawners)
        {
            // Trigger each spawner to spawn enemies
            spawner.SpawnEnemies();
            // Optionally add up all enemies spawned to totalEnemies, depending on your spawn logic
            totalEnemies += spawner.spawnCount;
        }
        // Increment the wave number for the next wave
        waveNumber++;
    }

    // Optional: Method to manually trigger a wave, can be called by external events or tests
    public void TriggerWaveManually()
    {
        timer = waveInterval;  // Set timer to interval to trigger wave on next Update
    }
}
