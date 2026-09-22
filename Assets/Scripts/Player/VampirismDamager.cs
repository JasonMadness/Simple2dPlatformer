using UnityEngine;

public class VampirismDamager : MonoBehaviour
{
    [SerializeField] private float _radius = 4f;
    [SerializeField] private float _damage = 5;
    [SerializeField] private LayerMask _enemyLayer;

    public float Radius => _radius;

    public float Damage()
    {
        Health target = FindNearestTarget();

        if (target == null)
            return 0;

        float damage = target.Decrease(_damage);

        return damage;
    }

    private Health FindNearestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

        Health nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Health health) == false)
                continue;

            float distance = Vector2.SqrMagnitude((Vector2)health.transform.position - (Vector2)transform.position);

            if (distance > _radius * _radius)
                continue;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = health;
            }
        }

        return nearestTarget;
    }
}
