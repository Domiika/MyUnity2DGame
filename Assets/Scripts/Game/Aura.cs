using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour, ISpell
{
    public float damage = 10f;
    public int spellLevel = 0;
    public float damageInterval = 0.5f;

    CircleCollider2D circleCollider;

    Transform player;

    bool isTrigger = false;

    List<Enemy> enemiesInAura = new List<Enemy>();




    // Start is called before the first frame update
    void Start()
    {
        damage = 10f;
        transform.localScale = new Vector3(1f, 1f, 1f);
        circleCollider = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; //GameObject.transform
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        
        if (Input.GetKeyDown("r"))
        {
            AuraScaleUp(0.20f);
        }
        if (Input.GetKeyDown("g"))
        {
            AuraScaleUp(0.80f);
        }


    }

    public void AuraScaleUp(float inputPercentage)
    {
        float percentage = inputPercentage + 1;
        transform.localScale *= percentage;
    }
    
    public void SpellLevelUp()
    {
        spellLevel++;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Enemy")) //Zkontroluje jestli object má tag "Enemy"
        {
            Enemy enemy = collider.GetComponent<Enemy>(); //Přířadíme komponent z kolidujícího objektu
            if (enemy != null && !enemiesInAura.Contains(enemy)) //Kontrolujeme jestli se objekt přiřadil k enemy a jestli už není v listu enemies
            {
                enemiesInAura.Add(enemy);
                enemy.TakeDamage(damage);
                isTrigger = true;
                StartCoroutine(DealDamageOverTime());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.CompareTag("Enemy")) 
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null && enemiesInAura.Contains(enemy))
            {
                enemiesInAura.Remove(enemy);
                if (enemiesInAura.Count == 0)
                {
                    isTrigger = false;
                    StopCoroutine(DealDamageOverTime());
                }
            }
        }
    }
    
    IEnumerator DealDamageOverTime()
    {
        while (isTrigger)
        {
            for (int i = enemiesInAura.Count - 1; i >= 0; i--)
            {
                if (enemiesInAura[i] != null)
                {
                    enemiesInAura[i].TakeDamage(damage);
                }
                else
                {
                    enemiesInAura.RemoveAt(i);
                }
            }
            yield return new WaitForSeconds(damageInterval);
        }
    }
    


}
