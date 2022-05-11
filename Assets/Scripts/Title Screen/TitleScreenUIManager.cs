using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TitleScreenUIManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField playerNameInputField;

    [SerializeField] private TextMeshProUGUI warningText,
        highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        warningText.text = null;

        highScoreText.text = "no high score recorded";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        string playerNameInput = playerNameInputField.text.Trim();

        if (playerNameInput == "")
        {
            warningText.text = "Enter you name below...";
        }
        else if (playerNameInput.Length > 10)
        {
            warningText.text = "Enter name with in 10 characters...";
        }
        else
        {
            //SceneManager.LoadScene("2 level");
        }
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
