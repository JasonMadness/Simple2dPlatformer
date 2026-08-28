using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(CharacterRotation))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 4f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _chaseSpeed = 3f;

    private float _direction = 1f;
    private Vector2 _startPosition;
    private float _minX;
    private float _maxX;

    private PlayerDetector _playerDetector;
    private CharacterRotation _characterRotation;

    private void Awake()
    {
        _playerDetector = GetComponent<PlayerDetector>();
        _characterRotation = GetComponent<CharacterRotation>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _minX = _startPosition.x - _xBoundary;
        _maxX = _startPosition.x + _xBoundary;
    }

    private void Update()
    {
        if (_playerDetector.IsPlayerDetected())
            ChasePlayer();
        else
            Patrol();
    }

    private void Patrol()
    {
        Move(_direction, _speed);

        float currentX = transform.position.x;

        if (currentX <= _minX || currentX >= _maxX)
        {
            float clampedX = Mathf.Clamp(
                currentX,
                _minX,
                _maxX);

            transform.position = new Vector3(
                clampedX,
                transform.position.y,
                transform.position.z);

            ChangeDirection();
        }
    }

    private void ChasePlayer()
    {
        Transform player = _playerDetector.Player;
        float directionToPlayer = Mathf.Sign(
            player.position.x - transform.position.x);

        _direction = directionToPlayer;

        Move(_direction, _chaseSpeed);
    }

    private void Move(float direction, float speed)
    {
        float moveX = direction * speed * Time.deltaTime;

        transform.Translate(moveX, 0f, 0f);

        _characterRotation.Face(direction);
    }

    private void ChangeDirection()
    {
        _direction *= -1f;
    }
}