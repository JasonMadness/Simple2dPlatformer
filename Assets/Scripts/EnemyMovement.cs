using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 4f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _chaseSpeed = 3f;
    [SerializeField] private float _detectionRange = 3f;
    [SerializeField] private float _sameLevelTolerance = 0.5f;

    private float _direction = 1f;
    private Vector2 _startPosition;

    private float _minX;
    private float _maxX;
    private SpriteRenderer _spriteRenderer;
    private Transform _player;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            _player = playerObject.transform;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _minX = _startPosition.x - _xBoundary;
        _maxX = _startPosition.x + _xBoundary;
    }

    private void Update()
    {
        if (IsPlayerInChaseRange())
            ChasePlayer();
        else
            Patrol();
    }

    private bool IsPlayerInChaseRange()
    {
        if (_player == null)
            return false;

        float horizontalDistance = Mathf.Abs(_player.position.x - transform.position.x);
        float verticalDistance = Mathf.Abs(_player.position.y - transform.position.y);

        return horizontalDistance <= _detectionRange && verticalDistance <= _sameLevelTolerance;
    }

    private void Patrol()
    {
        Move(_direction, _speed);

        float currentX = transform.position.x;

        if (currentX <= _minX || currentX >= _maxX)
        {
            float clampedX = Mathf.Clamp(currentX, _minX, _maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
            ChangeDirection();
        }
    }

    private void ChasePlayer()
    {
        float directionToPlayer = Mathf.Sign(_player.position.x - transform.position.x);
        _direction = directionToPlayer;

        Move(_direction, _chaseSpeed);
    }

    private void Move(float direction, float speed)
    {
        float moveX = direction * speed * Time.deltaTime;
        transform.Translate(moveX, 0f, 0f);

        _spriteRenderer.flipX = direction > 0f;
    }

    private void ChangeDirection()
    {
        _direction *= -1f;
    }
}

