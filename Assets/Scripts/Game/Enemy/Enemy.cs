using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player playerDamage;
    public float damageInterval = 1f;
    public float damage = 1f;
    public float enemyHealth = 50f;
    public GameObject xpPrefab;  
    public int xpAmount = 10; 
    public int score = 10;
    public Aura aura;
    public bool isInAuraActive;
    private Coroutine damageCoroutine;
    private bool isCollisionActive = false; 

    void Start()
    {
        playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (isInAuraActive && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(TakeDamageOverTime());
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DropXP();
        GameManager.instance.AddScore(score);
        Destroy(gameObject);
    }

    void DropXP()
    {
        GameObject xpOrb = Instantiate(xpPrefab, transform.position, Quaternion.identity);
        xpOrb.GetComponent<XPOrb>().SetXP(xpAmount);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Aura"))
        {
            aura = collider.GetComponent<Aura>();
            isInAuraActive = true;

            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(TakeDamageOverTime());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Aura"))
        {
            isInAuraActive = false;

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator TakeDamageOverTime()
    {
        while (isInAuraActive)
        {
            TakeDamage(aura.damage);
            yield return new WaitForSeconds(aura.damageInterval);
        }
        damageCoroutine = null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDamage.TakeDamage(damage);
            isCollisionActive = true;
            StartCoroutine(DealDamageOverTime());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollisionActive = false;
        }
    }

    IEnumerator DealDamageOverTime()
    {
        while (isCollisionActive)
        {
            playerDamage.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
