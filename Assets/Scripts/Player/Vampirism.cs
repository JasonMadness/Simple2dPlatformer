using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(VampirismDamager))]
[RequireComponent(typeof(VampirismView))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;

    private Health _health;
    private InputHandler _inputHandler;
    private VampirismDamager _damager;
    private VampirismView _view;

    private bool _isReady = true;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _inputHandler = GetComponent<InputHandler>();
        _damager = GetComponent<VampirismDamager>();
        _view = GetComponent<VampirismView>();

        _view.SetRadius(_damager.Radius);
        _view.Hide();
        _view.SetCharge(1f);
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

        while (remaining > 0f)
        {
            int damage = _damager.Damage(Time.deltaTime);

            if (damage > 0)
                _health.Increase(damage);

            remaining -= Time.deltaTime;
            _view.SetCharge(remaining / _duration);

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
            _view.SetCharge(1f - remaining / _cooldown);

            yield return null;
        }

        _view.SetCharge(1f);
        _isReady = true;
    }
}
