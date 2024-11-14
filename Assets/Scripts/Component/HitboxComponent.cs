using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent healthComponent;

    private void Awake()
    {
        // Cek jika HealthComponent ada di object yang sama
        healthComponent = GetComponent<HealthComponent>();
        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent not found on " + gameObject.name);
        }
    }

    // Method untuk mengurangi health dengan menerima damage dari Bullet
    public void Damage(Bullet bullet)
    {
        if (bullet != null)
        {
            healthComponent.Subtract(bullet.damage);
        }
    }

    // Method untuk mengurangi health dengan menerima integer damage
    public void Damage(int damage)
    {
        healthComponent.Subtract(damage);
    }
}

