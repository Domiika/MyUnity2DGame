using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpValue = 10;
    public float pickupRange = 0.5f;
    public float moveSpeed = 3f;
    private Transform player;

    public void SetXP(int amount)
    {
        xpValue = amount;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < pickupRange)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GainXP(xpValue);
            Destroy(gameObject);
        }
    }
}
