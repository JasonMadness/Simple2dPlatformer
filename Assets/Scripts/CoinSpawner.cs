using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints = new Transform[4];

    private GameObject _currentCoin;
    private readonly bool[] _isPointOccupied = new bool[4];
    private readonly List<int> _availableIndices = new List<int>();

    private void Awake()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _isPointOccupied[i] = false;
        }
    }

    private void Start()
    {
        SpawnInitialCoin();
    }

    public void NotifyCoinCollected()
    {
        if (_currentCoin != null)
        {
            Destroy(_currentCoin);
            _currentCoin = null;
        }

        SpawnNextCoin();
    }

    private void SpawnInitialCoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        _currentCoin = Instantiate(_coinPrefab, _spawnPoints[randomIndex].position, Quaternion.identity);
        _isPointOccupied[randomIndex] = true;
    }

    private void SpawnNextCoin()
    {
        _availableIndices.Clear();

        for (int i = 0; i < _isPointOccupied.Length; i++)
        {
            if (!_isPointOccupied[i])
            {
                _availableIndices.Add(i);
            }
        }

        if (_availableIndices.Count == 0)
        {
            for (int i = 0; i < _isPointOccupied.Length; i++)
            {
                _isPointOccupied[i] = false;
            }

            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _availableIndices.Add(i);
            }
        }

        int selectedIndex = _availableIndices[Random.Range(0, _availableIndices.Count)];
        _currentCoin = Instantiate(_coinPrefab, _spawnPoints[selectedIndex].position, Quaternion.identity);
        _isPointOccupied[selectedIndex] = true;
    }
}
