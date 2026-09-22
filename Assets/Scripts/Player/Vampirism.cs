using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(VampirismDamager))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _damageInterval = 0.5f;

    private Health _health;
    private InputHandler _inputHandler;
    private VampirismDamager _damager;

    private bool _isReady = true;

    public event Action<float> ChargeChanged;
    public event Action Activated;
    public event Action Deactivated;

    public float Radius => _damager.Radius;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _inputHandler = GetComponent<InputHandler>();
        _damager = GetComponent<VampirismDamager>();
    }

    private void OnEnable() => _inputHandler.VampirismButtonPressed += OnVampirismButtonPressed;
    private void OnDisable() => _inputHandler.VampirismButtonPressed -= OnVampirismButtonPressed;

    private void OnVampirismButtonPressed()
    {
        if (_isReady == false) 
            return;

        _isReady = false;
        StartCoroutine(Drain());
    }

    private IEnumerator Drain()
    {
        Activated?.Invoke();

        float remainingTime = _duration;
        float elapsedTime = 0f;

        while (remainingTime > 0f)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _damageInterval)
            {
                elapsedTime -= _damageInterval;
                float damage = _damager.Damage();

                if (damage > 0) 
                    _health.Increase(damage);
            }

            remainingTime -= Time.deltaTime;
            ChargeChanged?.Invoke(remainingTime / _duration);
            yield return null;
        }

        Deactivated?.Invoke();
        yield return Recharge();
    }

    private IEnumerator Recharge()
    {
        float remaining = _cooldown;

        while (remaining > 0f)
        {
            remaining -= Time.deltaTime;
            ChargeChanged?.Invoke(1f - remaining / _cooldown);
            yield return null;
        }

        ChargeChanged?.Invoke(1f);
        _isReady = true;
    }
}