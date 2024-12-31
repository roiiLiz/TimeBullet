using UnityEngine;

public interface IEntityMoveable
{
    public bool IsFacingRight { get; set; }

    void MoveTowards(Vector2 direction);

    void DetermineFacingDirection(Vector2 direction);
}