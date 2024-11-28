using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 2f;
    public GameObject enemyPrefab;

    private void Start()
    {
        // Posisikan musuh secara acak di bagian atas layar
        RespawnAtTop();
        
    }

    private void Update()
    {
        // Gerakkan musuh ke bawah
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Jika musuh keluar dari layar di bagian bawah, respawn di bagian atas layar
        if (transform.position.y < -Screen.height / 85f)
        {
            RespawnAtTop();
        }
    }

    // Method untuk memposisikan musuh secara acak di bagian atas layar
    private void RespawnAtTop()
    {
        float randomX = Random.Range(-Screen.width / 105f, Screen.width / 105f);
        transform.position = new Vector2(randomX, Screen.height / 85f);

        // Pastikan rotasi tetap pada keadaan awal (menghadap ke bawah secara natural)
        transform.rotation = Quaternion.identity;
    }

    
}