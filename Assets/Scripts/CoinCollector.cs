using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action Collected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Coin), out _))
        {
            Collected?.Invoke();
            Debug.Log("Coin collected!");
        }
    }
}
