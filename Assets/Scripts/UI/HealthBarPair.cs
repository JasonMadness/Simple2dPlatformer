using System;
using UnityEngine;

[Serializable]
public class HealthBarPair
{
    [SerializeField] private Health _health;
    [SerializeField] private Bar _bar;

    public Health Health => _health;
    public Bar Bar => _bar;
}
