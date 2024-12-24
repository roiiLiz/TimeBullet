using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletMovementSpeed = 20f;
    [SerializeField] private int bulletDamage = 2;
    [SerializeField] private float bulletDuration = 5f;

    public float customTimeScale;
    private float internalBulletTime;

    void OnEnable() { TimeStop.customTimeScale += UpdateCustomTime; }
    void OnDisable() { TimeStop.customTimeScale -= UpdateCustomTime; }

    void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletMovementSpeed * Time.deltaTime * customTimeScale);
        BulletDecay();
    }

    void BulletDecay()
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        HealthComponent healthComponent = collision.GetComponent<HealthComponent>();
        Debug.Log("healthComponent");
        
        if (healthComponent != null && !collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthComponent>().Damage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
