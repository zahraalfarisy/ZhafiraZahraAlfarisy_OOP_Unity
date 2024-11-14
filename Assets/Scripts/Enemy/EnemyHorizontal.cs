using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 2f;  // Speed at which the enemy moves
    private Vector2 moveDirection;
    public GameObject enemyPrefab;

    private void Start()
    {
        // Randomly position the enemy on either the left or right side of the screen
        PositionOnRandomSide();
        EnemyHorizontal.SpawnEnemies(enemyPrefab, Random.Range(3, 7));
    }

    private void Update()
    {
        // Move the enemy in a horizontal direction
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // If the enemy goes out of screen bounds on either side, reposition it on the opposite side
        if (transform.position.x < -Screen.width / 80f || transform.position.x > Screen.width / 80f)
        {
            PositionOnRandomSide();
        }
    }

    // Method to place the enemy at a random position on either the left or right side of the screen
    private void PositionOnRandomSide()
    {
        // Choose a random spawn side (left or right)
        float spawnX = Random.Range(0, 2) == 0 ? -Screen.width / 110f : Screen.width / 120f;
        float spawnY = Random.Range(-Screen.height / 80f, Screen.height / 80f);

        // Set the enemy's position at the chosen side with a random vertical position
        transform.position = new Vector2(spawnX, spawnY);

        // Set the horizontal movement direction based on the spawn side
        moveDirection = spawnX < 0 ? Vector2.right : Vector2.left;

        // Reset rotation to default (facing horizontally)
        transform.rotation = Quaternion.identity;
    }

    public static void SpawnEnemies(GameObject enemyPrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Create a new enemy instance
            GameObject newEnemy = Instantiate(enemyPrefab);
            EnemyHorizontal enemyScript = newEnemy.GetComponent<EnemyHorizontal>();
            if (enemyScript != null)
            {
                enemyScript.PositionOnRandomSide(); // Position it randomly on either side of the screen
            }
        }
    }
}
