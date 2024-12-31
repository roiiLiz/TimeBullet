using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private int score = 0;

    void Start()
    {
        text.text = $"Score: {score}";
    }

    void OnEnable() { Enemy.enemyDeath += IncrementScore; }
    void OnDisable() { Enemy.enemyDeath -= IncrementScore; }

    private void IncrementScore()
    {
        score++;

        text.text = $"Score: {score}";
    }
}
