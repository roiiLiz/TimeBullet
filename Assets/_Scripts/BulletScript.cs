using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private BulletType bulletType;
    public float bulletMovementSpeed = 20f;
    public int bulletDamage = 2;
    public int maxPierce = 1;

    [SerializeField]
    private float bulletDuration = 5f;

    public float customTimeScale;
    private float internalBulletTime;

    private enum BulletType { Player, Enemy }

    private void OnEnable() { TimeStop.customTimeScale += UpdateCustomTime; }
    private void OnDisable() { TimeStop.customTimeScale -= UpdateCustomTime; }

    private void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * bulletMovementSpeed * Time.deltaTime * customTimeScale);
        BulletDecay();
    }

    private void BulletDecay()
    {
        if (customTimeScale == 1)
        {
            internalBulletTime += Time.deltaTime;
        }
        else if (customTimeScale > 1)
        {
            internalBulletTime += Time.deltaTime * customTimeScale;
        }

        if (internalBulletTime >= bulletDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable healthComponent = collision.GetComponent<IDamagable>();
        
        switch (bulletType)
        {
            case BulletType.Player:
                if (healthComponent != null && !collision.CompareTag("Player"))
                {
                    DealDamageTo(healthComponent);
                }
                break;
            case BulletType.Enemy:
                if (healthComponent != null && collision.CompareTag("Player"))
                {
                    DealDamageTo(healthComponent);
                }
                break;
            default:
                break;
        }

    }

    private void DealDamageTo(IDamagable healthComponent)
    {
        healthComponent.TakeDamage(bulletDamage);
        maxPierce--;

        if (maxPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
