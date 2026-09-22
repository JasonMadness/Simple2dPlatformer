using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";

    [SerializeField] private KeyCode _vampirismKey = KeyCode.V;

    private float _horizontal;

    public float Horizontal => _horizontal;
    public event Action JumpPressed;
    public event Action VampirismButtonPressed;

    private void Update()
    {
        _horizontal = Input.GetAxis(HorizontalAxis);

        if (Input.GetButtonDown(JumpButton))
            JumpPressed?.Invoke();

        if (Input.GetKeyDown(_vampirismKey))
            VampirismButtonPressed?.Invoke();
    }
}
