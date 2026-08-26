using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _contactRange = 0.8f;
    [SerializeField] private float _damageCooldown = 1f;

    private float _currentCooldown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TryDealDamage(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryDealDamage(other);
    }

    private void Update()
    {
        _currentCooldown -= Time.deltaTime;

        if (_currentCooldown < 0)
            _currentCooldown = 0;
    }

    private void TryDealDamage(Collider2D other)
    {
        if (_currentCooldown <= 0 && other.TryGetComponent(out Health otherHealth))
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);

            if (distance < _contactRange)
            {
                otherHealth.TakeDamage(_damage);
                _currentCooldown = _damageCooldown;
            }
        }
    }
}
