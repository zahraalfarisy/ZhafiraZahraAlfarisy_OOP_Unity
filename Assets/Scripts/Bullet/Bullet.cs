using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;

    private Rigidbody2D rb;
    private IObjectPool<Bullet> objectPool;

    // Called by the pool to set the reference
    public void SetPool(IObjectPool<Bullet> pool)
    {
        objectPool = pool;
    }

    // Called to reset the bullet's velocity and other properties
    public void Initialize()
    {
        // Ensure Rigidbody2D is set
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    private void ReturnToPool()
    {
        objectPool.Release(this);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if bullet hits an enemy
        if (other.CompareTag("Enemy"))
        {
            // Handle enemy damage logic here, e.g., other.GetComponent<Enemy>().TakeDamage(damage);

            // Return the bullet to the pool after it hits an enemy
            ReturnToPool();
        }
    }

    void Update()
    {
        // Return bullet to pool if it travels too far
        if (transform.position.magnitude > 50) // Example distance limit
        {
            ReturnToPool();
        }
    }
}