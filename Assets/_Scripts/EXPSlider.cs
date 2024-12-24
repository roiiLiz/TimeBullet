using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI text;

    private void OnEnable() { PlayerEXP.expInfo += UpdateDisplay; }
    private void OnDisable() { PlayerEXP.expInfo -= UpdateDisplay; }

    private void UpdateDisplay(int currentExp, int expToNextLevel, int currentLevel)
    {
        // init
        slider.maxValue = expToNextLevel;
        slider.value = currentExp;
        text.text = $"Current Level: {currentLevel}";
    }
}
