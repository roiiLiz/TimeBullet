using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private HealthComponent playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();

        slider.maxValue = playerHealth.MaxHealth;
        slider.value = playerHealth.CurrentHealth;
    }

    private void Update()
    {
        slider.value = playerHealth.CurrentHealth;
    }
}
