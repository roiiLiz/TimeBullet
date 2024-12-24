using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Boost Power", menuName = "Power Ups/Speed Boost")]
public class SpeedBoost : BasePowerUp
{
    [SerializeField, Range(0, 2), Tooltip("The speed increase in percentage, e.g. 0.35 = 35% increase, etc.")] 
    private float speedIncrease = 0.35f;

    public override void AddToList(BasePowerUp powerUp)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeInventory>().currentPowerUps.Add(this);
    }

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<PlayerMovement>() != null)
        {
            target.GetComponent<PlayerMovement>().movementSpeed = target.GetComponent<PlayerMovement>().movementSpeed * (1 + speedIncrease);
        }
    }
}
