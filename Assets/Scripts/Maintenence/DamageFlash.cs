using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]
public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.red;
    [SerializeField] private float _flashDuration = 0.5f;

    private SpriteRenderer _spriteRenderer;
    private Health _health;
    private Color _originalColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
        _originalColor = _spriteRenderer.color;
    }

    private void OnEnable()
    {
        _health.DamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        _health.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken()
    {
        StartCoroutine(ShowFlash());
    }

    private IEnumerator ShowFlash()
    {
        _spriteRenderer.color = _flashColor;
        yield return new WaitForSeconds(_flashDuration);
        _spriteRenderer.color = _originalColor;
    }
}
