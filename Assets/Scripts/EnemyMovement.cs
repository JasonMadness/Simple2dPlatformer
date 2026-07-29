using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 4f;

    private void Move()
    {
        float xPosition = Mathf.PingPong(Time.time, _xBoundary) - _xBoundary;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
