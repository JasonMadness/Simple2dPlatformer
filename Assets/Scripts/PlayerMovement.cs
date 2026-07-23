using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheckPoint;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalInput;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if (_groundCheckPoint == null)
        {
            var child = transform.Find("GroundCheck");
            _groundCheckPoint = child != null ? child : transform;
        }
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded)
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

    private void OnDrawGizmosSelected()
    {
        Transform checkTransform = _groundCheckPoint != null ? _groundCheckPoint : transform;
        Gizmos.color = _isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(checkTransform.position, _groundCheckRadius);
    }
}
