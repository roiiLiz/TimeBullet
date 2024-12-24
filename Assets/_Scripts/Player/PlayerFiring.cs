using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] 
    private Transform firingPoint;
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField] 
    private float shotsPerSecond;

    private float customTimeScale;

    private bool canFire = true;
    private float internalDelay;

    private GameObject player;

    private void OnEnable() { TimeStop.customTimeScale += UpdateCustomTime; }
    private void OnDisable() { TimeStop.customTimeScale -= UpdateCustomTime; }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }

    private void Update()
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

    private void FireBullet()
    {
        canFire = false;

        var bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);

        bullet.GetComponent<BulletScript>().customTimeScale = customTimeScale;

        player.GetComponent<UpgradeInventory>().ApplyUpgradesTo(bullet);
    }
}
