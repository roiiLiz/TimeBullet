using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Boost Power", menuName = "Power Ups/Damage Boost")]
public class DamageBoost : BasePowerUp
{
    [SerializeField] 
    private int damageIncrease = 1;

    public override void AddToList(BasePowerUp powerUp)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeInventory>().currentPowerUps.Add(this);
    }

    public override void ApplyPowerUp(GameObject target)
    {
        if (target.GetComponent<BulletScript>() != null)
        {
            target.GetComponent<BulletScript>().bulletDamage += damageIncrease;
        }
    }
}
