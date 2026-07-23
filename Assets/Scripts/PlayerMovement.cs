using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string JumpButtonName = "Jump";
    private const string SpeedParameterName = "Speed";

    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheckPoint;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _horizontalInput;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(HorizontalAxisName);

        float speed = Mathf.Abs(_horizontalInput);
        _animator.SetFloat(SpeedParameterName, speed);

        FlipSprite();

        if (Input.GetButtonDown(JumpButtonName) && _isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;
        CheckGround();
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);
    }

    private void FlipSprite()
    {
        if (_horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
