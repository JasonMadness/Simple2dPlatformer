using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Vampirism))]
public class VampirismBar : Bar
{
    [SerializeField] private Slider _slider;

    private Vampirism _vampirism;
    private float _maxValue = 1f;
    private float _currentValue = 1f;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
        Initialize(_currentValue, _maxValue);
    }

    private void OnEnable()
    {
        _vampirism.ChargeChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _vampirism.ChargeChanged -= OnValueChanged;
    }

    protected override void UpdateView()
    {
        _slider.value = CurrentValue / MaxValue;
    }
}