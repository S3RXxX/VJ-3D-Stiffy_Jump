using UnityEngine;

public class RotateCoins : MonoBehaviour
{   
    public float rotationSpeed = 90.0f;
    private Vector3 rotation;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        rotation = new Vector3(0.0f, rotationSpeed * Time.fixedDeltaTime, 0.0f);
        transform.Rotate(rotation);
        // GetComponent<CharacterController>().
    }
}
