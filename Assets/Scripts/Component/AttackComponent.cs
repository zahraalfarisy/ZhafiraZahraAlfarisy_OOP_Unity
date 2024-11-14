using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;  // Bullet used for attacking
    public int attackDamage; // Amount of damage dealt by this object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has a HitboxComponent
        HitboxComponent targetHitbox = collision.GetComponent<HitboxComponent>();

        // If the collided object has a different tag and possesses a HitboxComponent
        if (targetHitbox != null)
        {
            // Apply damage to the object using the bullet
            targetHitbox.Damage(bullet);

    
        }
    }
}
