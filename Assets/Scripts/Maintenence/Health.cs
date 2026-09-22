using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 100;

    private float _current;

    public event Action<float> ValueChanged;
    public event Action DamageTaken;
    public event Action Ended;

    public float Current => _current;
    public float Max => _max;

    private void Awake()
    {
        _current = _max;
    }

    public float Decrease(float damage)
    {
        if (_current <= 0)
            return 0;

        _current -= damage;

        if (_current <= 0)
        {
            float remainingDamage = -_current;
            _current = 0;
            Ended?.Invoke();
            return remainingDamage;
        }

        DamageTaken?.Invoke();
        ValueChanged?.Invoke(_current);

        return damage;
    }

    public void Increase(float amount)
    {
        _current += amount;

        if (_current > _max)
            _current = _max;

        ValueChanged?.Invoke(_current);
    }
}