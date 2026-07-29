using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinSpawner coinSpawner = FindObjectOfType<CoinSpawner>();

            if (coinSpawner != null)
            {
                coinSpawner.NotifyCoinCollected();
            }
        }
    }
}
