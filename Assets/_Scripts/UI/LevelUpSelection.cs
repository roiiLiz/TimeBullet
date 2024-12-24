using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSelection : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup levelUpUI;

    public static event Action levelUpStart;

    void OnEnable() {  PlayerEXP.levelUp += BeginLevelUpSelection; CardInfo.selectedCard += EndLevelUpSelection; }
    void OnDisable() {  PlayerEXP.levelUp -= BeginLevelUpSelection; CardInfo.selectedCard -= EndLevelUpSelection; }

    private void BeginLevelUpSelection()
    {
        Debug.Log("Beginning level up");
        levelUpUI.alpha = 1.0f;
        levelUpUI.blocksRaycasts = true;
        levelUpUI.interactable = true;
        levelUpStart?.Invoke();
        Time.timeScale = 0f;
    }

    private void EndLevelUpSelection()
    {
        Debug.Log("Leaving level up sequence");
        levelUpUI.alpha = 0f;
        levelUpUI.blocksRaycasts = false;
        levelUpUI.interactable = false;
        Time.timeScale = 1f;
    }
}
