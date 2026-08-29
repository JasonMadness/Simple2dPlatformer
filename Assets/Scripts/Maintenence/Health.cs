using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    private int _current;

    public event Action DamageTaken;
    public event Action Died;

    public int Current => _current;
    public int Max => _max;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(int damage)
    {
        _current -= damage;  
        DamageTaken?.Invoke();

        if (_current <= 0)
        {
            _current = 0;
            Died?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        _current += amount;

        if (_current > _max)
            _current = _max;
    }
}