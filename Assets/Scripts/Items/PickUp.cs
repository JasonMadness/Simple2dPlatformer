using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public event Action<GameObject> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
