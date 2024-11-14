using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public float movementSpeed = 2f;
    private Vector2 movementDirection;
    private SpriteRenderer spriteRendererComponent;

    private void Start()
    {
        // Set enemy position randomly on either the left or right side of the screen
        SetRandomSidePosition();
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Move the enemy horizontally
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Respawn enemy on the opposite side if it goes off-screen horizontally
        if (transform.position.x < -Screen.width / 80f || transform.position.x > Screen.width / 80f)
        {
            SetRandomSidePosition();
        }
    }

    // Method to randomly position the enemy on the left or right screen side
    private void SetRandomSidePosition()
    {
        // Randomly select spawn side (left or right)
        float xPosition = Random.Range(0, 2) == 0 ? Screen.width / 120f : -Screen.width / 110f;
        float yPosition = Random.Range(-Screen.height / 80f, Screen.height / 80f);

        // Set enemy position with a random Y position and on the chosen side
        transform.position = new Vector2(xPosition, yPosition);

        // Set horizontal movement direction based on spawn side
        movementDirection = xPosition < 0 ? Vector2.right : Vector2.left;

        spriteRendererComponent.flipX = movementDirection == Vector2.left; // Flip sprite if moving left

        // Keep rotation at default horizontal
        transform.rotation = Quaternion.identity;
    }
}
