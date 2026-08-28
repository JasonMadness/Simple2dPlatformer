using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";

    private float _horizontal;

    public float Horizontal => _horizontal;
    public event Action JumpPressed;

    private void Update()
    {
        _horizontal = Input.GetAxis(HorizontalAxis);

        if (Input.GetButtonDown(JumpButton))
            JumpPressed?.Invoke();
    }
}
