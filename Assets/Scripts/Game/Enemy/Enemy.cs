using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player playerDamage;
    public float damageInterval = 1f;
    public float damage = 1f;
    public float enemyHealth = 50f;
    private bool isCollisionActive = false;
    public GameObject xpPrefab;  // Prefab XP, který spadne po smrti
    public int xpAmount = 10; 
    



    // Start is called before the first frame update
    void Start()
    {
        playerDamage = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(this.gameObject);
    }

    void DropXP()
    {
        GameObject xpOrb = Instantiate(xpPrefab, transform.position, Quaternion.identity);
        xpOrb.GetComponent<XPOrb>().SetXP(xpAmount);
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
        isCollisionActive = false;
        StopCoroutine(DealDamageOverTime());
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
