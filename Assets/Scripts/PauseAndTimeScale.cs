using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseAndTimeScale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeScaleText;
    
    public void Pause() {
        Time.timeScale = 0;
    }
    
    public void Resume() {
        Time.timeScale = 1;
    }

    public void SpeedUp()
    {
        if (Time.timeScale < 3)
        {
            Time.timeScale += 0.5f;
            timeScaleText.text = "Speed: x" + Time.timeScale;
        }
    }
    
    public void SpeedDown()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale -= 0.5f;
            timeScaleText.text = "Speed: x" + Time.timeScale;
        }
    }
}
