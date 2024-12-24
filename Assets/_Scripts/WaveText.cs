using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void OnEnable() { WaveSpawner.currentWave += UpdateText; }
    private void OnDisable() { WaveSpawner.currentWave -= UpdateText; }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateText(int waveNumber)
    {
        text.text = $"Current Wave: {waveNumber}";
    }
}
