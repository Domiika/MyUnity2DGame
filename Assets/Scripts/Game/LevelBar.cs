using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetLevel(float level)
    {
        slider.value = level;
    }
}
