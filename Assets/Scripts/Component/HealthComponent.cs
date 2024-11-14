using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    private float health;

    // Getter untuk properti health
    public float Health => health;

    // Setter untuk mengurangi nilai health
    public void Subtract(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Hapus object jika health <= 0
        }
    }

    // Inisialisasi health dengan maxHealth
    private void Start()
    {
        health = maxHealth;
    }
}
