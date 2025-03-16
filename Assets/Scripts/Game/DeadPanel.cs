using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class DeadPanel : MonoBehaviour
{
    [SerializeField] GameObject deadPanel; 
    [SerializeField] TextMeshProUGUI timeScore;
    
    
    public void OnPlayerDeath()
    {
        // Získá čas od spuštění levelu
        float elapsedTime = Time.timeSinceLevelLoad;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeScore.text = string.Format("Timer: {0:00}:{1:00}\nScore: {2}", minutes, seconds, GameManager.instance.score);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
