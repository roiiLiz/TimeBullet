using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    public static event Action levelRetry;

    public void GoToLevel(String levelName)
    {
        if (levelName != null)
        {
            SceneManager.LoadScene(levelName);
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }

    public void RetryLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);

        levelRetry?.Invoke();
    }
}




