using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public void Face(float direction)
    {
        float yRotation = direction > 0f ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}