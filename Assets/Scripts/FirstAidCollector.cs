using UnityEngine;

[RequireComponent(typeof(Health))]
public class FirstAidCollector : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _health.Heal(firstAidKit.HealAmount);
            Destroy(firstAidKit.gameObject);
        }
    }
}