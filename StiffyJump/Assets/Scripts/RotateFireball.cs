using UnityEngine;

public class RotateFireball : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Speed of texture rotation
    private Vector3 rotationAxis = new Vector3(0, 0, 1);

    void FixedUpdate()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.fixedDeltaTime);
    }

}
