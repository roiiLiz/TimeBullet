using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Enemy Death Component", fileName = "Enemy Death Component")]
public class EnemyDeathComponent : DeathComponent
{
    [SerializeField]
    private int expOnDeath = 1;

    public static event Action enemyDeath;
    public static event Action<int> giveExp;

    public override void Die(MonoBehaviour context)
    {
        enemyDeath?.Invoke();
        giveExp?.Invoke(expOnDeath);
        Destroy(context.gameObject);
    }
}
