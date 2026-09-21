using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheckPoint;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(
            _groundCheckPoint.position,
            _groundCheckRadius,
            _groundLayer);
    }
}