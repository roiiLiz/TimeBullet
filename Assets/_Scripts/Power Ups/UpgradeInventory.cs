using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInventory : MonoBehaviour
{
    public List<BasePowerUp> currentPowerUps = new List<BasePowerUp>();

    private void Start()
    {
        currentPowerUps.Clear();
    }

    public void ApplyUpgradesTo(GameObject target)
    {
        foreach (BasePowerUp power in currentPowerUps)
        {
            power.ApplyPowerUp(target);
        }
    }
}
