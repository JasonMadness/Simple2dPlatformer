using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Bar _playerHealthBar;
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private Bar _enemyHealthBar;

    private void Start()
    {
        _playerHealthBar.Initialize(_playerHealth.Max, _playerHealth.Current);
        _enemyHealthBar.Initialize(_enemyHealth.Max, _enemyHealth.Current);
    }

    private void OnEnable()
    {
        _playerHealth.ValueChanged += _playerHealthBar.OnValueChanged;
        _enemyHealth.ValueChanged += _enemyHealthBar.OnValueChanged;
    }

    private void OnDisable()
    {
        _playerHealth.ValueChanged -= _playerHealthBar.OnValueChanged;
        _enemyHealth.ValueChanged -= _enemyHealthBar.OnValueChanged;
    }
}
