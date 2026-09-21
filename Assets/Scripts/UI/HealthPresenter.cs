using UnityEngine;

public class HealthPresenter
{
    private readonly Health _health;
    private readonly Bar _bar;

    public HealthPresenter(Health health, Bar bar)
    {
        _health = health;
        _bar = bar;
    }

    public void Enable()
    {
        _bar.Initialize(_health.Current, _health.Max);
        _health.ValueChanged += _bar.OnValueChanged;
    }

    public void Disable()
    {
        _health.ValueChanged -= _bar.OnValueChanged;
    }
}
