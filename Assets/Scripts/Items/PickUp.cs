using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public event Action<PickUp> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
