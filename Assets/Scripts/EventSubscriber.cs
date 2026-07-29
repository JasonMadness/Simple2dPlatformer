using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private CoinCollector _coinCollector;

    private void OnEnable()
    {
        _coinCollector.Collected += _coinSpawner.OnCoinCollected;
    }

    private void OnDisable()
    {
        _coinCollector.Collected -= _coinSpawner.OnCoinCollected;
    }
}
