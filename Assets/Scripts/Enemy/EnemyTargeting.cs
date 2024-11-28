using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform targetPlayerTransform; // Player's position
    private float movementSpeed = 2.0f;      // Movement speed of the enemy
    public GameObject enemyTemplate;         // Prefab for EnemyTargeting

    private void Start()
    {
        // Locate the Player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Ensure the Player is found before setting the transform
        if (playerObject != null)
        {
            targetPlayerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player not found in the scene. EnemyTargeting will remain stationary.");
        }

        // Randomly spawn multiple enemies
       
    }

    private void Update()
    {
        // Move towards the Player if it has been found
        if (targetPlayerTransform != null)
        {
            // Calculate direction towards the Player
            Vector2 movementDirection = (targetPlayerTransform.position - transform.position).normalized;
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the enemy if it collides with the Player
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the enemy upon contact with the Player
        }
    }

    // Method to spawn multiple enemies on the left or right side of the screen
    
}
