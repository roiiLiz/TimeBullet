using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shotsPerSecond;

    float customTimeScale;

    bool canFire = true;
    float internalDelay;

    void OnEnable() { TimeStop.customTimeScale += UpdateCustomTime; }
    void OnDisable() { TimeStop.customTimeScale -= UpdateCustomTime; }

    void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            FireBullet();
        }

        internalDelay += Time.deltaTime;

        if (internalDelay >= (1 / shotsPerSecond))
        {
            internalDelay = 0f;
            canFire = true;
        }
    }

    void FireBullet()
    {
        canFire = false;

        var bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        bullet.GetComponent<BulletScript>().customTimeScale = customTimeScale;
    }
}
