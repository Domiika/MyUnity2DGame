using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShotManager : MonoBehaviour
{
    public GameObject spellToSpawn;
    Transform player;
    public float timeToSpawn;
    private float spawnCounter;
    public float speed;
    public float damage;

   // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnCounter = timeToSpawn;
        speed = 5f;
        damage = 10f;
        timeToSpawn = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0f)
        {
            spawnCounter = timeToSpawn;

            Instantiate(spellToSpawn, transform.position, transform.rotation);              
        }
    }

    
}
