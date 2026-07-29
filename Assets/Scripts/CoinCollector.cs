using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action Collected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out _))
            Collected?.Invoke();
    }
}
