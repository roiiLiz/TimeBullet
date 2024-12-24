using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    Slider slider;
    [SerializeField] Image sliderImage;
    [SerializeField] Color cooldownColor;

    void OnEnable() { TimeStop.abilityProgress += AbilityProgress; TimeStop.cooldownBegin += BeginCooldown; }
    void OnDisable() { TimeStop.abilityProgress -= AbilityProgress; TimeStop.cooldownBegin -= BeginCooldown; }

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void AbilityProgress(float abilityProgress, float maxDuration)
    {
        sliderImage.color = Color.white;
        slider.value = abilityProgress * slider.maxValue / maxDuration;
    }

    void BeginCooldown(float timeToCooldown, float cooldownTime)
    {
        sliderImage.color = cooldownColor;
        slider.value = timeToCooldown * slider.maxValue / cooldownTime;
    }
}
