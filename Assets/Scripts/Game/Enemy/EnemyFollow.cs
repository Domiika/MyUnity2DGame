using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference na hráče (přiřaď v inspektoru nebo dynamicky)
    public float moveSpeed = 2f; // Rychlost pohybu nepřítele

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void FixedUpdate()
    {      
        if (player != null)
        {
            // Vypočítej směr k hráči
            Vector2 direction = (player.position - transform.position).normalized;

            // Pohybuj nepřítelem směrem k hráči
            rb.velocity = direction * moveSpeed;
        }
    }


}
