using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _healAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.Heal(_healAmount);
            Destroy(gameObject);
        }
    }
}
