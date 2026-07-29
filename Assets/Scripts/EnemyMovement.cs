using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 4f;
    [SerializeField] private float _speed = 2f;

    private float _direction = 1f;
    private Vector2 _startPosition;

    private float _minX;
    private float _maxX;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _minX = _startPosition.x - _xBoundary;
        _maxX = _startPosition.x + _xBoundary;
    }

    private void Update()
    {
        float moveX = _direction * _speed * Time.deltaTime;
        transform.Translate(moveX, 0f, 0f);

        float currentX = transform.position.x;

        if (currentX <= _minX || currentX >= _maxX)
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        _direction *= -1f;
        _spriteRenderer.flipX = _direction > 0;
    }
}
