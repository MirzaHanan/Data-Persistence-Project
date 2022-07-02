using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour
{

    public static GlobalController Instance;
    public string name;
    public int highScorePoints;
   
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    public void ReadStringInput(string input)
    {
        name = input;
    }

    public void SetHighScorePoint(int highScore)
    {
        highScorePoints = highScore;
    }

    public string GetName()
    {
        return name;
    }

    public int GetHighScorePoints()
    {
        return highScorePoints;
    }

    private void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
    }
}
