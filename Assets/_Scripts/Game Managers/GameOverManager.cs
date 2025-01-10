using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    private void OnEnable() { PlayerDeathComponent.playerDied += InitiateGameOver; UI_Button.levelRetry += InitiateCleanup; }
    private void OnDisable() { PlayerDeathComponent.playerDied -= InitiateGameOver; UI_Button.levelRetry += InitiateCleanup; }

    private void InitiateCleanup()
    {
        StartCoroutine(CleanUpGameOver());
    }

    private IEnumerator CleanUpGameOver()
    {
        yield return new WaitForSecondsRealtime(2);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void InitiateGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
