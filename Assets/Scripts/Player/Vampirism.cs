using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(VampirismDamager))]
[RequireComponent(typeof(VampirismView))]
[RequireComponent(typeof(VampirismBar))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _damageInterval = 0.5f;

    private Health _health;
    private InputHandler _inputHandler;
    private VampirismDamager _damager;
    private VampirismView _view;
    private VampirismBar _vampirismBar;

    private bool _isReady = true;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _inputHandler = GetComponent<InputHandler>();
        _damager = GetComponent<VampirismDamager>();
        _view = GetComponent<VampirismView>();
        _vampirismBar = GetComponent<VampirismBar>();

        _view.SetRadius(_damager.Radius);
        _view.Hide();

        _vampirismBar.Initialize(1f, 1f);
    }

    private void OnEnable()
    {
        _inputHandler.VampirismPressed += OnVampirismPressed;
    }

    private void OnDisable()
    {
        _inputHandler.VampirismPressed -= OnVampirismPressed;
    }

    private void OnVampirismPressed()
    {
        if (!_isReady)
            return;

        _isReady = false;
        StartCoroutine(Drain());
    }

    private IEnumerator Drain()
    {
        _view.Show();

        float remaining = _duration;
        float elapsed = 0f;

        while (remaining > 0f)
        {
            elapsed += Time.deltaTime;

            if (elapsed >= _damageInterval)
            {
                elapsed -= _damageInterval;

                float damage = _damager.Damage();

                if (damage > 0)
                    _health.Increase(damage);
            }

            remaining -= Time.deltaTime;
            _vampirismBar.OnValueChanged(remaining / _duration);

            yield return null;
        }

        _view.Hide();

        yield return Recharge();
    }

    private IEnumerator Recharge()
    {
        float remaining = _cooldown;

        while (remaining > 0f)
        {
            remaining -= Time.deltaTime;
            _vampirismBar.OnValueChanged(1f - remaining / _cooldown);

            yield return null;
        }

        _vampirismBar.OnValueChanged(1f);
        _isReady = true;
    }
}