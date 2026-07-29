using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            Debug.Log("Player detected!");
    }
}
