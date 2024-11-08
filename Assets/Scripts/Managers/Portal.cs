using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 50f;
    private Vector3 newPosition;

    private void Start()
    {
        SetRandomPosition();
    }

    private void Update()
    {
        // Pindahkan posisi perlahan ke arah newPosition
        if (transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }

        // Jika posisi telah hampir dicapai, set ulang newPosition
        if (Vector3.Distance(transform.position, newPosition) < 0.5f)
        {
            SetRandomPosition();
        }

        // Rotasi objek terus-menerus
        RotatePortal();

        // Periksa apakah Player memiliki weapon dan atur tampilan portal
        UpdatePortalState(PlayerHasWeapon());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.LoadScene("Main");
            }
            else
            {
                Debug.LogWarning("LevelManager not found in the scene.");
            }
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);
        newPosition = new Vector3(randomX, randomY, 0f);
    }

    private void RotatePortal()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private bool PlayerHasWeapon()
    {
        GameObject player = GameObject.FindWithTag("Player");
        return player != null && player.GetComponentInChildren<Weapon>() != null;
    }

    private void UpdatePortalState(bool isEnabled)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var collider = GetComponent<Collider2D>();

        if (spriteRenderer != null) spriteRenderer.enabled = isEnabled;
        if (collider != null) collider.enabled = isEnabled;
    }
}