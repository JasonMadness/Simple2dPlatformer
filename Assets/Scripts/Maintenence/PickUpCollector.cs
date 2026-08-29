using UnityEngine;

[RequireComponent(typeof(Health))]
public class PickUpCollector : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PickUp pickUp)
        {
            if (pickUp is Coin)
            {
                pickUp.Collect();
            }

            else if (pickUp is FirstAidKit)
            {
                _health.Heal(pickUp.HealAmount);
                Destroy(pickUp.gameObject);
            }
    }
}
