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

    [SerializeField] private GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.bestScorePlayer == "")
        {
            highScoreText.text = "No High Score Recorded";
        }
        else
        {
            highScoreText.text = "High Score\n"+GameManager.Instance.bestScore + " ( " + GameManager.Instance.bestScorePlayer + " ) ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score : "+score+" ( "+GameManager.Instance.currentPlayerName+" ) " ;
    }

    public void SetHealth(int health)
    {
        healthText.text = health+" : Health";
        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("2 level");
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("1 menu");
    }
}
