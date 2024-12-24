using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField, Tooltip("Movement speed of enemy in units per second")]
    private float enemyMovementSpeed = 2.5f;
    [SerializeField, Tooltip("Rotational speed of enemy in degrees per second")] 
    private float enemyRotationSpeed = 45f;
    [SerializeField]
    private int expAmountOnDeath;

    private Vector2 playerCurrentPosition;
    private float customTimeScale;
    private GameObject player;

    public static event Action requestTime;
    public static event Action enemyDeath;
    public static event Action<int> giveExp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        requestTime?.Invoke();
    }

    private void OnEnable() 
    {
        TimeStop.customTimeScale += UpdateCustomTime; 
    }

    private void OnDisable() 
    {
        enemyDeath?.Invoke();
        giveExp?.Invoke(expAmountOnDeath);

        TimeStop.customTimeScale -= UpdateCustomTime; 
    }

    private void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime * customTimeScale);
    }

    private void RotateToPlayer()
    {
        Vector2 lookDirection = ((Vector2) transform.position - (Vector2) player.transform.position).normalized;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        var targetAngle = Quaternion.AngleAxis(lookAngle, Vector3.forward);
        float rotationalSpeed = enemyRotationSpeed * Time.deltaTime * customTimeScale;

        if (rotationalSpeed == 0)
        {
            return;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, rotationalSpeed);
    }

    // Update is called once per frame
    private void Update()
    {
        RotateToPlayer();
        MoveToPlayer();
    }
}
