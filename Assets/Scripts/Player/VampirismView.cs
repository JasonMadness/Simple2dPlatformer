using UnityEngine;
using UnityEngine.UI;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _area;
    [SerializeField] private Slider _chargeSlider;

    public void SetRadius(float radius)
    {
        Sprite sprite = _area.sprite;
        float spriteSize = sprite == null ? 1f : sprite.bounds.size.x;

        _area.transform.localScale = Vector3.one * (radius * 2f / spriteSize);
    }

    public void Show()
    {
        _area.enabled = true;
    }

    public void Hide()
    {
        _area.enabled = false;
    }

    public void SetCharge(float value)
    {
        _chargeSlider.value = value;
    }
}
