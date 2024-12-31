using System;
using Unity;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField]
    private float attackRange = 10f;
    [SerializeField]
    private int attacksPerSecond = 1;
    [SerializeField]
    private GameObject gunPivot;
    [SerializeField]
    private Transform firingPoint;
    [SerializeField]
    private GameObject bulletPrefab;

    private bool canFire = true;
    private float weaponCooldown = 0f;

    private void Update()
    {
        if (base.customTimeScale == 0f)
        {
            return;
        }

        RotateGunPivot();

        if (base.DistanceToPlayer() <= attackRange)
        {
            if (canFire)
            {
                FireBullet();
            } else
            {
                ManageWeaponCooldown();
            }
        }
        else
        {
            base.MoveTowards(base.DirectionToPlayer());
        }
    }

    private void ManageWeaponCooldown()
    {
        weaponCooldown += Time.deltaTime * base.customTimeScale;

        if (weaponCooldown >= 1 / attacksPerSecond)
        {
            weaponCooldown = 0f;
            canFire = true;
        }
    }

    private void FireBullet()
    {
        canFire = false;

        var bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        bullet.GetComponent<BulletScript>().customTimeScale = base.customTimeScale;
    }

    private void RotateGunPivot()
    {
        float lookAngle = Mathf.Atan2(DirectionToPlayer().y, DirectionToPlayer().x) * Mathf.Rad2Deg;

        gunPivot.transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.forward);
    }
}