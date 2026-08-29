using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectionRange = 3f;
    [SerializeField] private float _sameLevelTolerance = 0.5f;

    private Transform _player;
    private bool _isPlayerDetected;

    public Transform Player => _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            _player = other.transform;
            _isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            _isPlayerDetected = false;
            _player = null;
        }
    }

    public bool IsPlayerDetected()
    {
        return _isPlayerDetected && _player != null;
    }
}

