using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : Bar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private float _epsilon = 0.0001f;
    private float _targetValue;

    private void Update()
    {
        if (Mathf.Abs(_slider.value - _targetValue) > _epsilon)
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);

        Debug.Log(_slider.value + " " + _targetValue);
    }

    protected override void UpdateView()
    {
        _targetValue = (float)CurrentValue / MaxValue;        
    }
}
