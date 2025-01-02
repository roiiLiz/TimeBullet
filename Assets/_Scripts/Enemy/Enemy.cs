using System;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;

public class Enemy : MonoBehaviour, IDamagable, IEntityMoveable
{

#region "Variables + Setup"

    [SerializeField]
    private float movementSpeed = 2.5f;
    protected float customTimeScale;
    [SerializeField]
    private int expAmountOnDeath = 1;

    [field: SerializeField] 
    public int MaxHealth { get; set; } = 5;
    public int CurrentHealth { get; set; }
    public bool IsFacingRight { get; set; }

    public static event Action requestTime;
    public static event Action enemyDeath;
    public static event Action<int> giveExp;

    GameObject player => GameObject.FindGameObjectWithTag("Player");
    SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    private void OnEnable() { TimeStop.customTimeScale += UpdateCustomTime; }
    private void OnDisable() { TimeStop.customTimeScale -= UpdateCustomTime; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        requestTime?.Invoke();
    }

#endregion
#region "Time-Stop"

    private void UpdateCustomTime(float incomingTimeScale)
    {
        customTimeScale = incomingTimeScale;
    }

#endregion
#region "IDamagable"

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
        enemyDeath?.Invoke();
        giveExp?.Invoke(expAmountOnDeath);
        
        Debug.Log("Enemy Died!");

        Destroy(gameObject);
    }

#endregion
#region "IEntityMoveable"

    public void MoveTowards(Vector2 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime * customTimeScale);
    }

    protected Vector2 DirectionToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        return new Vector2(direction.x, direction.y).normalized;
    }

    protected float DistanceToPlayer()
    {
        return Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
    }

    public void DetermineFacingDirection(Vector2 direction)
    {
        if (sprite == null) 
        { 
            Debug.LogWarning("Sprite Renderer not found");
            return;
        }

        if (direction.x == 0) 
        {
            return;
        }

        if (direction.x < 0) 
        { 
            sprite.flipX = true; 
        }
        else 
        { 
            sprite.flipX = false; 
        }
    }
}

#endregion