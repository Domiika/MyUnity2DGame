using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth = 100;
    public float currentHealth;
    public LevelBar levelBar;
    public float currentXP = 0f;
    public float maxXP = 20f;
    public int level = 1;
    public GameObject levelUpPanel;
    public GameObject deadPanel;
    public AudioManager audioManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        levelBar.SetLevel(0f);
        GameManager.instance.RestartGame();
        Time.timeScale = 0;       
    }

    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainXP(50);
            Debug.Log("Current XP: "+currentXP+"\n Current Level: "+level);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void GainXP(float amount) 
    {
        currentXP = levelBar.slider.value + amount;
        levelBar.SetLevel(currentXP);

        if (currentXP >= maxXP)
        {
            while (currentXP >= maxXP)
            {
                currentXP -= maxXP;
                levelBar.SetLevel(currentXP);
                LevelUp();
                StartCoroutine(Wait());
            }
        } 
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

    public void Die()
    {
        Time.timeScale = 0;
        deadPanel.SetActive(true);
        FindObjectOfType<DeadPanel>().OnPlayerDeath();
        audioManager.Death();
    }
    public void LevelUp()
    {
        level++;
        Time.timeScale = 0;
        levelUpPanel.SetActive(true);
        maxXP*=1.2f;
        levelBar.SetMaxValue(maxXP);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
