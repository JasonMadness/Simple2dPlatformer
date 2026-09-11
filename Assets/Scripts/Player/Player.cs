using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Ended += OnHealthEnded;
    }

    private void OnDisable()
    {
        _health.Ended -= OnHealthEnded;
    }

    private void OnHealthEnded()
    {
        gameObject.SetActive(false);
    }
}