using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}