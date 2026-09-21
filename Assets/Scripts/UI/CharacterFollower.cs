using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 1.5f, 0f);

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
        transform.rotation = Quaternion.identity;
    }
}
