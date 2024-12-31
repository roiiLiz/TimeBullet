using Unity;

public interface IDamagable
{
    int MaxHealth { get; set; }

    int CurrentHealth { get; set; }

    void TakeDamage(int damageAmount);

    void Die();
}