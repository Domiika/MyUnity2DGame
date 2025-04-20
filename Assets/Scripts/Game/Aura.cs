using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour, ISpell
{
    public float damage = 10f;
    public int spellLevel = 0;
    public float damageInterval = 1f;
    public float auraScale;

    Transform player;

    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = player.position;
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
}
