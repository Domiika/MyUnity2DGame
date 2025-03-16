using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] GameObject levelUpPanel;
    public Aura aura;
    public Shot shot;
    public SpellShotManager spellShotManager;
    public Player playerLevel;
    int button1Level = 0;
    int button2Level = 0;
    int button3Level = 0;
    int auraLevel = 0;
    int blastLevel = 0;
    int thunderboltLevel = 0;
    public TextMeshProUGUI auraLevelText;
    public TextMeshProUGUI blastLevelText;
    public TextMeshProUGUI thunderboltLevelText;
    public GameObject auraObj;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public TextMeshProUGUI textButton1;
    public TextMeshProUGUI textButton21;
    public TextMeshProUGUI textButton22;
    public GameObject unlockText1;
    public TextMeshProUGUI textButton3;

    
    public void Button1()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;

        if (button1Level == 0)
        {
            GameObject newAura = Instantiate(auraObj, transform.position, transform.rotation);
            aura = newAura.GetComponent<Aura>();
            item1.SetActive(true);
            button1Level++;
            textButton1.text = "+20% area";
            textButton1.color = Color.white;
            auraLevel++;
        }
        else if (button1Level == 1)
        {
            aura.AuraScaleUp(0.20f);
            button1Level++;
            textButton1.text = "+5 damage";
            Debug.Log("Aura size: " + aura.transform.localScale);
            auraLevel++;
        }
        else if (button1Level == 2)
        {
            aura.damage += 5f;
            button1Level = 1;
            textButton1.text = "+20% area";
            Debug.Log("currentDamage: "+ aura.damage);
            auraLevel++;
        }   
        auraLevelText.text = "Lvl. " + auraLevel; 

    }

    public void Button2()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;

        if (button2Level == 0)
        {
           Instantiate(spellShotManager, transform.position, transform.rotation);
           button2Level++;
           item2.SetActive(true);
           textButton21.text = "-20% cooldown";
           textButton22.text = "+5 damage";
           Destroy(unlockText1);
           blastLevel++;
        }

        else if (button2Level == 1)
        {
            spellShotManager.timeToSpawn *= 0.8f;
            spellShotManager.damage += 5f;
            textButton21.text = "+5% speed";
            textButton22.text = "+5 damage";
            blastLevel++;
        }
        else if (button2Level == 2)
        {
            spellShotManager.speed *= 1.05f;
            spellShotManager.damage += 5f;
            button2Level = 1;
            textButton21.text = "-20% cooldown";
            textButton22.text = "+5 damage";
            blastLevel++;
        }
        blastLevelText.text = "Lvl. " + blastLevel; 

    }

    public void Button3()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
