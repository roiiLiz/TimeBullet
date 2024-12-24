using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStopIndicator : MonoBehaviour
{
    [SerializeField] Image panel;
    private float panelAlpha;

    void OnEnable() { TimeStop.isTimeOn += ControlVisual; }
    void OnDisable() { TimeStop.isTimeOn -= ControlVisual; }

    void Start()
    {
        panelAlpha = panel.color.a;

        panel.color = new Color(0, 0, 0, 0);
    }

    void ControlVisual(bool isTimeOn)
    {
        if (isTimeOn)
        {
            panel.color = new Color(0, 0, 0, panelAlpha);
        } else
        {
            panel.color = new Color(0, 0, 0, 0);
        }
    }
}
