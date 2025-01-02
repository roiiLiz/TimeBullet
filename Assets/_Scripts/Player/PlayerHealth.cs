using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [field: SerializeField] public int MaxHealth { get; set; } = 10;
    public int CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died");
    }

}
