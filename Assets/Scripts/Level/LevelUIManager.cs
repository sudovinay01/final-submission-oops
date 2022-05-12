using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText,
        scoreText,
        healthText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "No High Score Recorded";
        scoreText.text = "Score : 0";
        healthText.text = "0 : Health";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("1 menu");
    }
}
