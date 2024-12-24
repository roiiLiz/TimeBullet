using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Boost Power", menuName = "Power Ups/Damage Boost")]
public class DamageBoost : BasePowerUp
{
    private PowerUpType powerUpType = PowerUpType.BULLET;

    [SerializeField] 
    private int damageIncrease = 1;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<BulletScript>() != null)
        {
            target.GetComponent<BulletScript>().bulletDamage += damageIncrease;
        }
    }

    public override PowerUpType ReturnType()
    {
        return powerUpType;
    }
}
