using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public SpellShotManager spellShotManager;
    public float rotateSpeed = 200f;
    private Transform target;

    void Start()
    {
        FindNearestEnemy();
    }

    void Update()
    {
        if (target == null)
        {
            FindNearestEnemy(); 
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        transform.position += transform.right * spellShotManager.speed * Time.deltaTime;
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;
        GameObject closestEnemyObject = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        if (closestEnemy != null)
        {
            target = closestEnemy;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(spellShotManager.damage);
            Destroy(this.gameObject);
        }
    }
}
