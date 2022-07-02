using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour
{

    public static GlobalController Instance;
    public string playerName;
    public string bestPlayerName;
    public int highScorePoints;
   
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            GlobalController.Instance.LoadScore();
        }
        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    public void ReadStringInput(string input)
    {
        playerName = input;
    }

    public void SetHighScorePoint(int highScore)
    {
        highScorePoints = highScore;
    }

    public string GetName()
    {
        return bestPlayerName;
    }

    public void newBestPlayer()
    {
        bestPlayerName = playerName;
    }

    public int GetHighScorePoints()
    {
        return highScorePoints;
    }

    private class SaveData
    {
        public string name;
        public int highScorePoints;
    }

    public void SaveScore()
    {
        SaveData saveData = new SaveData();
        saveData.name = playerName;
        saveData.highScorePoints = highScorePoints;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.dataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = saveData.name;
            highScorePoints = saveData.highScorePoints;
        }
    }
}
