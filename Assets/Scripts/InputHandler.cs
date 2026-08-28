using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string JumpButtonName = "Jump";

    public event Action JumpPressed;

    private float _horizontal;

    public float Horizontal
    {
        get { return _horizontal; }
    }

    private void Update()
    {
        _horizontal = Input.GetAxis(HorizontalAxisName);

        if (Input.GetButtonDown(JumpButtonName))
        {
            JumpPressed?.Invoke();
        }
    }
}
