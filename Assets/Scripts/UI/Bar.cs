using UnityEngine;

public class Bar : MonoBehaviour
{
    protected int CurrentValue { get; private set; }
    protected int MaxValue { get; private set; }

    public void Initialize(int currentValue, int maxValue)
    {
        MaxValue = maxValue;
        SetValue(currentValue);
    }

    public void OnValueChanged(int currentValue)
    {
        SetValue(currentValue);
    }

    protected virtual void UpdateView() { }

    private void SetValue(int currentValue)
    {
        CurrentValue = currentValue;
        UpdateView();
    }
}
