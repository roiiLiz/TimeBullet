using UnityEngine;

public enum PowerUpType
{
    MOVEMENT,
    BULLET,
    TIME,
    HEALTH,
    META
}

public abstract class BasePowerUp : ScriptableObject
{
    public abstract void ApplyPowerUp(GameObject target);
    public abstract PowerUpType ReturnType();
}
