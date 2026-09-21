using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : Bar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private float _epsilon = 0.0001f;
    private float _targetValue;
    private Coroutine _smoothUpdateCoroutine;

    protected override void UpdateView()
    {
        if (MaxValue <= 0)
            return;

        _targetValue = (float)CurrentValue / MaxValue;

        if (_smoothUpdateCoroutine != null)
            StopCoroutine(_smoothUpdateCoroutine);

        _smoothUpdateCoroutine = StartCoroutine(SmoothUpdate());
    }

    private IEnumerator SmoothUpdate()
    {
        while (Mathf.Abs(_slider.value - _targetValue) > _epsilon)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
            yield return null;
        }

        _smoothUpdateCoroutine = null;
    }
}
