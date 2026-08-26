using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectionRange = 3f;
    [SerializeField] private float _sameLevelTolerance = 0.5f;

    private Transform _player;

    public Transform Player => _player;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            _player = playerObject.transform;
    }

    public bool IsPlayerDetected()
    {
        if (_player == null)
            return false;

        float horizontalDistance = Mathf.Abs(_player.position.x - transform.position.x);
        float verticalDistance = Mathf.Abs(_player.position.y - transform.position.y);

        return horizontalDistance <= _detectionRange && verticalDistance <= _sameLevelTolerance;
    }
}
