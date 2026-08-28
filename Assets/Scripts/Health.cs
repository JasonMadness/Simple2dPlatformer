using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public event Action DamageTaken;
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        DamageTaken?.Invoke();

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}