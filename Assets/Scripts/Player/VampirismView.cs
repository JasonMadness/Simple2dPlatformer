using UnityEngine;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _area;
    [SerializeField] private Vampirism _vampirism;

    private void Start()
    {
        SetRadius(_vampirism.Radius);
        Hide();
    }

    private void OnEnable()
    {
        _vampirism.Activated += Show;
        _vampirism.Deactivated += Hide;
    }

    private void OnDisable()
    {
        _vampirism.Activated -= Show;
        _vampirism.Deactivated -= Hide;
    }

    private void SetRadius(float radius)
    {
        Sprite sprite = _area.sprite;
        float spriteSize = sprite.bounds.size.x;
        _area.transform.localScale = Vector3.one * (radius * 2f / spriteSize);
    }

    private void Show() => _area.enabled = true;
    private void Hide() => _area.enabled = false;
}