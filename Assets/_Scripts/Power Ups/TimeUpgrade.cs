using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Time Dialation Power", menuName = "Power Ups/Time Dialation")]
public class TimeUpgrade : BasePowerUp
{
    private PowerUpType powerUpType = PowerUpType.TIME;

    public static event Action<string> removeTimeSelection;

    [SerializeField]
    private float increasedEffect = 0.25f;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<TimeStop>() != null)
        {
            target.GetComponent<TimeStop>().slowDownScale -= increasedEffect;
            if (target.GetComponent<TimeStop>().slowDownScale == 0) 
            {
                removeTimeSelection?.Invoke(this.name);
            }
        }
    }

    public override PowerUpType ReturnType()
    {
        return powerUpType;
    }
}
