using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }

    public int MaxHealth()
    {
        return maxHealth;
    }

    public void Damage(int incomingDamage)
    {
        currentHealth -= incomingDamage;
        Debug.Log($"{gameObject.name} took {incomingDamage} damage!");

        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} Died!");
            Destroy(gameObject);
        }
    }
}
