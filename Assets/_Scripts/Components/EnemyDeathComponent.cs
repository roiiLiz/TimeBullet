using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Enemy Death Component", fileName = "Enemy Death Component")]
public class EnemyDeathComponent : DeathComponent
{
    public static event Action enemyDeath;

    public override void Die(MonoBehaviour context)
    {
        enemyDeath?.Invoke();
        Destroy(context.gameObject);
    }
}
