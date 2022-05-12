using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int score=0,
        health = 3;


    private LevelUIManager levelUIManager;

    // ENCAPSULATION
    public int scoreData
    {
        get { return score; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("Adding negative values for score is not allowed.");
            }
            else
            {
                score = value;
                levelUIManager.SetScore(score);
                //Debug.Log(score);
            }
        }
    }

    // ENCAPSULATION
    public int helthData
    {
        get { return health; }
        set
        {
            health = value;
            levelUIManager.SetHealth(health);
        }
    }

    public bool isGameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        levelUIManager = GameObject.Find("Level UI").GetComponent<LevelUIManager>();
        levelUIManager.SetHealth(health);
        levelUIManager.SetScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
