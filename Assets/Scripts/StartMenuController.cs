using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Text BestScoreText;
    private GlobalController globalController;

    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void BestScore()
    {
        BestScoreText.text = $"Best Score by {globalController.playerName} is {globalController.highScorePoints}";
    }

    private void Start()
    {
        
    }
}