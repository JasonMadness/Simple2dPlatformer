using UnityEngine;

public class Bar : MonoBehaviour
{
    protected float CurrentValue { get; private set; }
    protected float MaxValue { get; private set; }

    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        SetValue(currentValue);
    }

    public void OnValueChanged(float currentValue)
    {
        SetValue(currentValue);
    }

    protected virtual void UpdateView() { }

    private void SetValue(float currentValue)
    {
        CurrentValue = currentValue;
        UpdateView();
    }
}
