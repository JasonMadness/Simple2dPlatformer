using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(CharacterRotator))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMover : MonoBehaviour
{
    private const string SpeedParameterName = "Speed";

    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 15f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private InputHandler _inputHandler;
    private CharacterRotator _characterRotation;
    private GroundDetector _groundDetector;

    private float _horizontalInput;
    private bool _jumpRequested;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inputHandler = GetComponent<InputHandler>();
        _characterRotation = GetComponent<CharacterRotator>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _inputHandler.JumpPressed += OnJumpPressed;
    }

    private void OnDisable()
    {
        _inputHandler.JumpPressed -= OnJumpPressed;
    }

    private void Update()
    {
        _horizontalInput = _inputHandler.Horizontal;

        float speed = Mathf.Abs(_horizontalInput);
        _animator.SetFloat(SpeedParameterName, speed);

        if (!Mathf.Approximately(_horizontalInput, 0f))
            _characterRotation.Face(_horizontalInput);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(
            _horizontalInput * _moveSpeed,
            _rigidbody2D.velocity.y);

        _rigidbody2D.velocity = movement;

        if (_jumpRequested && _groundDetector.IsGrounded)
        {
            _rigidbody2D.velocity = new Vector2(
                _rigidbody2D.velocity.x,
                _jumpForce);
        }

        _jumpRequested = false;
    }

    private void OnJumpPressed()
    {
        _jumpRequested = true;
    }
}
