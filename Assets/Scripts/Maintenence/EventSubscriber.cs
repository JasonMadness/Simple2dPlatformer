using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Bar _playerHealthBar;

    private void OnEnable()
    {
        _playerHealth.ValueChanged += _playerHealthBar.OnValueChanged;
    }

    private void OnDisable()
    {
        _playerHealth.ValueChanged -= _playerHealthBar.OnValueChanged;
    }
}
