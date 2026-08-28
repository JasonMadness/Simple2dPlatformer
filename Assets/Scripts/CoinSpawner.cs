using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private Coin _coin;
    private int _currentSpawnPointIndex = -1;

    private void Start()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        int spawnPointIndex = GetRandomSpawnPointIndex();
        _coin = Instantiate(_coinPrefab, _spawnPoints[spawnPointIndex].position, Quaternion.identity);
        _currentSpawnPointIndex = spawnPointIndex;
        _coin.Collected += OnCoinCollected;
    }

    private void OnCoinCollected(Coin coin)
    {
        coin.gameObject.SetActive(false);

        int spawnPointIndex = GetRandomSpawnPointIndex();

        coin.transform.position = _spawnPoints[spawnPointIndex].position;
        _currentSpawnPointIndex = spawnPointIndex;

        coin.gameObject.SetActive(true);
    }

    private int GetRandomSpawnPointIndex()
    {
        int index;

        do
        {
            index = Random.Range(0, _spawnPoints.Length);
        }
        while (index == _currentSpawnPointIndex);

        return index;
    }

    private void OnDisable()
    {
        _coin.Collected -= OnCoinCollected;
    }
}