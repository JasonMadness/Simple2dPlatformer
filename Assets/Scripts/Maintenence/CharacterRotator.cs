using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterRotator : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Face(float direction)
    {
        _spriteRenderer.flipX = direction < 0f;
    }
}