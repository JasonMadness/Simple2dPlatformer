using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints = new Transform[4];

    private Coin _coin;
    private bool[] _isPointOccupied;

    private void Start()
    {
        _isPointOccupied = new bool[_spawnPoints.Length];
        ClearAllSpawnPoints();
        SpawnInitialCoin();
    }

    public void OnCoinCollected()
    {
        _coin.SetActive(false);
        MoveCoinToNextPosition();
    }

    private void ClearAllSpawnPoints()
    {
        for (int i = 0; i < _isPointOccupied.Length; i++)
            _isPointOccupied[i] = false;
    }

    private void SpawnInitialCoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        _coin = Instantiate(_coinPrefab, _spawnPoints[randomIndex].position, Quaternion.identity);
        _isPointOccupied[randomIndex] = true;
    }

    private void MoveCoinToNextPosition()
    {
        int freePointIndex;

        do
        {
            freePointIndex = Random.Range(0, _spawnPoints.Length);
        }
        while (_isPointOccupied[freePointIndex]);

        ClearAllSpawnPoints();
        _isPointOccupied[freePointIndex] = true;
        _coin.transform.position = _spawnPoints[freePointIndex].position;
        _coin.SetActive(true);
    }
}
