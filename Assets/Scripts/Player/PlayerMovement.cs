using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;

    [SerializeField] private Vector2 maxSpeed = new Vector2(7, 5);
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(1, 1);
    [SerializeField] private Vector2 timeToStop = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 stopClamp = new Vector2(2.5f, 2.5f);

    // Define the boundary limits
    [SerializeField] private Rect movementBounds = new Rect(-8, -4, 16, 8);

    private Vector2 moveDirection;

    void Start()
    {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Initial calculations for movement and friction based on both x and y components
        moveVelocity = Vector2.zero;

        moveFriction.x = (timeToFullSpeed.x > 0) ? maxSpeed.x / timeToFullSpeed.x : 0;
        moveFriction.y = (timeToFullSpeed.y > 0) ? maxSpeed.y / timeToFullSpeed.y : 0;

        stopFriction.x = (timeToStop.x > 0) ? maxSpeed.x / timeToStop.x : 0;
        stopFriction.y = (timeToStop.y > 0) ? maxSpeed.y / timeToStop.y : 0;
    }

    public void Move()
    {
        // Capture input for movement
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveDirection != Vector2.zero)
        {
            // Increase velocity based on moveFriction and clamp to maxSpeed
            moveVelocity += moveDirection * moveFriction * Time.fixedDeltaTime;
            moveVelocity = Vector2.ClampMagnitude(moveVelocity, maxSpeed.magnitude);
        }
        else
        {
            // Apply stop friction
            moveVelocity -= moveVelocity.normalized * stopFriction * Time.fixedDeltaTime;

            // Clamp to stop if below threshold
            if (moveVelocity.magnitude < stopClamp.magnitude)
            {
                moveVelocity = Vector2.zero;
            }
        }

        // Apply velocity to Rigidbody
        rb.velocity = moveVelocity;

        // Clamp the player's position within the boundary limits
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(rb.position.x, movementBounds.xMin, movementBounds.xMax),
            Mathf.Clamp(rb.position.y, movementBounds.yMin, movementBounds.yMax)
        );
        rb.position = clampedPosition;
    }

    private Vector2 GetFriction()
    {
        // Return friction based on movement or stopping
        return moveDirection != Vector2.zero ? moveFriction * moveDirection : stopFriction * -rb.velocity.normalized;
    }

    public bool IsMoving()
    {
        // Returns true if player is moving, false otherwise
        return rb.velocity.magnitude > 0;
    }
}
