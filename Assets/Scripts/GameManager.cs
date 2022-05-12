using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string currentPlayerName;

    public string bestScorePlayer;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    class SaveData
    {
        public string bestScorePlayer_Save;
        public int bestScore_Save;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScorePlayer_Save = Instance.bestScorePlayer;
        data.bestScore_Save = Instance.bestScore;

        string json = JsonUtility.ToJson(data);
        //Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instance.bestScorePlayer = data.bestScorePlayer_Save;
            Instance.bestScore = data.bestScore_Save;
        }
    }
}
