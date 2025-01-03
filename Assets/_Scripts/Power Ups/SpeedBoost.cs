using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Boost Power", menuName = "Power Ups/Speed Boost")]
public class SpeedBoost : BasePowerUp
{
    private PowerUpType powerUpType = PowerUpType.MOVEMENT;

    [SerializeField, Range(0, 2), Tooltip("The speed increase in percentage, e.g. 0.35 = 35% increase, etc.")] 
    private float speedIncrease = 0.35f;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<PlayerMovement>() != null)
        {
            target.GetComponent<PlayerMovement>().movementSpeed = target.GetComponent<PlayerMovement>().movementSpeed * (1 + speedIncrease);
        }
    }

    public override PowerUpType ReturnType()
    {
        return powerUpType;
    }
}
