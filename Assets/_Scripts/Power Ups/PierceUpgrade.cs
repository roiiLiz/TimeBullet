using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pierce Upgrade", menuName = "Power Ups/Pierce")]
public class PierceUpgrade : BasePowerUp
{
    private PowerUpType powerUpType = PowerUpType.BULLET;

    [SerializeField]
    private int addedPierce = 1;

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<BulletScript>() != null)
        {
            target.GetComponent<BulletScript>().maxPierce += addedPierce;
        }
    }

    public override PowerUpType ReturnType()
    {
        return powerUpType;
    }
}
