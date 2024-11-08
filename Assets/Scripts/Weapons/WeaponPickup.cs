using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] public Weapon weaponHolder; 

    private Weapon weapon;

    private void Awake()
    {
        weapon = Instantiate(weaponHolder, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        ToggleWeaponVisual(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("Bukan Objek Player yang memasuki Trigger");
            return;
        }

        Weapon playerWeapon = other.gameObject.GetComponentInChildren<Weapon>();

        if (playerWeapon != null)
        {
            RepositionWeapon(playerWeapon);
        }

        AttachWeaponToPlayer(other.transform);
        Debug.Log("Weapon picked up by player.");
    }

    private void RepositionWeapon(Weapon playerWeapon)
    {
        playerWeapon.transform.SetParent(transform, false);
        playerWeapon.transform.localPosition = Vector3.zero;
        ToggleWeaponVisual(false, playerWeapon);
    }

    private void AttachWeaponToPlayer(Transform playerTransform)
    {
        weapon.parentTransform = playerTransform;
        weapon.transform.SetParent(playerTransform);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localScale = Vector3.one;

        ToggleWeaponVisual(true, weapon);
    }

    private void ToggleWeaponVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }

    private void ToggleWeaponVisual(bool on, Weapon specificWeapon)
    {
        if (specificWeapon != null)
        {
            specificWeapon.gameObject.SetActive(on);
        }
    }
}
