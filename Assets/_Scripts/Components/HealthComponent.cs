using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private DeathComponent deathComponent;
    [SerializeField]
    private DamageFlashComponent damageFlashComponent;

    public int MaxHealth { get { return maxHealth; }}
    public int CurrentHealth { get { return currentHealth; }}

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(Attack attack)
    {
        currentHealth -= attack.damageAmount;
        damageFlashComponent.BeginDamageFlash();

        if (currentHealth <= 0)
        {
            if (deathComponent != null)
            {
                deathComponent.Die(this);
            }
        }
    }
}
