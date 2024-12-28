using System.Collections;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    private Vector3 rotation;
    private float currentRotation = 0.0f;
    public void ActivateTrap()
    {
        StartCoroutine(DelayedActivateTrap());
    }
    private IEnumerator DelayedActivateTrap()
    {
        while (currentRotation < 90.0f) 
        {
            float rotationStep = rotationSpeed * Time.fixedDeltaTime;

            // Ensure we don't overshoot 90 degrees
            if (currentRotation + rotationStep > 90.0f)
            {
                rotationStep = 90.0f - currentRotation;
            }

            // Apply rotation
            transform.Rotate(0.0f, 0.0f, rotationStep);

            currentRotation += rotationStep;
            yield return null;
        }
        //yield return null;
    }
}
