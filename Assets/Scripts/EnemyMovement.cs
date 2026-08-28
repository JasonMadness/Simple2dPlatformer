using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(CharacterRotation))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 4f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _chaseSpeed = 3f;

    private float _direction = 1f;
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
        _minX = - _xBoundary;
        _maxX = + _xBoundary;
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
        float currentX = transform.position.x;

        if (currentX <= _minX && _direction < 0f)
            ChangeDirection();
        else if (currentX >= _maxX && _direction > 0f)
            ChangeDirection();

        Move(_direction, _speed);
    }

    private void ChasePlayer()
    {
        float deltaX = _playerDetector.Player.position.x - transform.position.x;
        _direction = Mathf.Sign(deltaX);

        Move(_direction, _chaseSpeed);
    }

    private void Move(float direction, float speed)
    {
        float moveX = direction * speed * Time.deltaTime;

        transform.Translate(
            moveX,
            0f,
            0f);

        _characterRotation.Face(direction);
    }

    private void ChangeDirection()
    {
        _direction *= -1f;
    }
}
