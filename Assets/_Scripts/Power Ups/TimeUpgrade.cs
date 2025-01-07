using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Time Dialation Power", menuName = "Power Ups/Time Dialation")]
public class TimeUpgrade : BasePowerUp
{
    private PowerUpType powerUpType = PowerUpType.TIME;

    [SerializeField]
    private float increasedEffect = 0.25f;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<TimeStop>() != null)
        {
            target.GetComponent<TimeStop>().slowDownScale -= increasedEffect;
        }
    }

    public override PowerUpType ReturnType()
    {
        return powerUpType;
    }
}
