using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndTimeScale : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeScaleText;
    private GameManager _gameManager;

    private void Start()
    {
        Time.timeScale = 1f;
        _gameManager = FindObjectOfType<GameManager>();
    }

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

    public void BackToMenu()
    {
        _gameManager.SaveCoinsToFile();
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        _gameManager.SaveCoinsToFile();
        SceneManager.LoadScene(1);
    }
}
