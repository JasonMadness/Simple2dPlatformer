using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static event Action Collected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Collected?.Invoke();
        }
    }
}
