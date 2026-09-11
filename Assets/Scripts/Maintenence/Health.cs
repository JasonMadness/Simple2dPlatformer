using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    private int _current;

    public event Action<int> ValueChanged;
    public event Action DamageTaken;
    public event Action Ended;

    public int Current => _current;
    public int Max => _max;

    private void Awake()
    {
        _current = _max;
    }

    public void Decrease(int damage)
    {
        _current -= damage;

        if (_current <= 0)
        {
            _current = 0;
            Ended?.Invoke();
        }

        DamageTaken?.Invoke();
        ValueChanged?.Invoke(_current);
    }

    public void Increase(int amount)
    {
        _current += amount;

        if (_current > _max)
            _current = _max;

        ValueChanged?.Invoke(_current);
    }
}