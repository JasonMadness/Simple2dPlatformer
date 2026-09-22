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

    public void Decrease(float damage)
    {
        if (_current <= 0)
            return;

        _current -= damage;

        if (_current <= 0)
        {
            _current = 0;
            Ended?.Invoke();
            return;
        }

        DamageTaken?.Invoke();
        ValueChanged?.Invoke(_current);
    }

    public void Increase(float amount)
    {
        _current += amount;

        if (_current > _max)
            _current = _max;

        ValueChanged?.Invoke(_current);
    }
}