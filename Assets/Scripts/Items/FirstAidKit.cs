using UnityEngine;

public class FirstAidKit : PickUp
{
    [SerializeField] private int _healAmount = 20;

    public int HealAmount => _healAmount;
}