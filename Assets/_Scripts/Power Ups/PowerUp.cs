using UnityEngine;

public abstract class BasePowerUp : ScriptableObject
{
    public abstract void ApplyPowerUp(GameObject target);

    public abstract void AddToList(BasePowerUp powerUp);
}
