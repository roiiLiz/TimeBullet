using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

enum TimeState
{
    Idle,
    Active,
    Cooldown
}

public class TimeStop : MonoBehaviour
{
    public static event Action<bool> isTimeOn;

    public static event Action<float> customTimeScale;
    public static event Action<float, float> abilityProgress;
    public static event Action<float, float> cooldownBegin; 

    public float slowDownScale = 0.5f;
    [SerializeField] 
    private float defaultSpeed = 1f;
    [SerializeField] 
    private float powerDuration = 5f;
    [SerializeField] 
    private float powerCooldownTime = 2f;

    private float internalPowerTime;
    private float internalCooldown;
    TimeState currentTimeState = TimeState.Idle;

    void OnEnable() { Enemy.requestTime += ReturnTime; }
    void OnDisable() { Enemy.requestTime -= ReturnTime; }

    void Start()
    {
        internalPowerTime = powerDuration;
        internalCooldown = 0f;
    }

    void Update()
    {
        ApplyTimePower();
        AcceptPlayerInput();
    }

    void ApplyTimePower()
    {
        switch (currentTimeState)
        {
            case TimeState.Idle:
                customTimeScale?.Invoke(defaultSpeed);
                abilityProgress?.Invoke(internalPowerTime, powerDuration);

                internalPowerTime += Time.deltaTime;
                if (internalPowerTime > powerDuration)
                {
                    internalPowerTime = powerDuration;
                }

                break;
            case TimeState.Active:
                isTimeOn?.Invoke(true);
                customTimeScale?.Invoke(slowDownScale);
                abilityProgress?.Invoke(internalPowerTime, powerDuration);

                internalPowerTime -= Time.deltaTime;
                if (internalPowerTime <= 0f)
                {
                    internalPowerTime = powerDuration;
                    currentTimeState = TimeState.Cooldown;

                    isTimeOn?.Invoke(false);
                }

                break;
            case TimeState.Cooldown:
                customTimeScale?.Invoke(defaultSpeed);
                cooldownBegin?.Invoke(internalCooldown, powerCooldownTime);

                internalCooldown += Time.deltaTime;
                if (internalCooldown >= powerCooldownTime)
                {
                    currentTimeState = TimeState.Idle;
                    internalCooldown = 0f;
                }   

                break;
        }
    }

    void AcceptPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (currentTimeState)
            {
                case TimeState.Idle:
                    Debug.Log("Activating time powers...");
                    isTimeOn?.Invoke(true);
                    currentTimeState = TimeState.Active;
                    break;
                case TimeState.Active:
                    Debug.Log("Disabling time powers...");
                    isTimeOn?.Invoke(false);
                    currentTimeState = TimeState.Idle;
                    break;
                case TimeState.Cooldown:
                    Debug.Log("Tried to activate time powers while on cooldown...");
                    break;
            }
        }
    }

    void ReturnTime()
    {
        switch (currentTimeState)
        {
            case TimeState.Active:
                customTimeScale?.Invoke(slowDownScale);
                break;
            default:
                customTimeScale?.Invoke(defaultSpeed);
                break;
        }
    }
}
