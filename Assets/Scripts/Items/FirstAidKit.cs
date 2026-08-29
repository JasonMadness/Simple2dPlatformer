using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _healAmount = 20;

    public int HealAmount => _healAmount;
}