using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _healAmount;

    public int HealAmount => _healAmount;

    public event Action<PickUp> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
