using UnityEngine;

public class RotateObstacles : MonoBehaviour
{
    private Vector3 rotation;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacleTurnL")
        {
            rotation = new Vector3(0.0f, -90.0f, 0.0f);
            GetComponent<CharacterController>().transform.Rotate(rotation);
        }
        else if (other.tag == "obstacleTurnR")
        {
            rotation = new Vector3(0.0f, 90.0f, 0.0f);
            GetComponent<CharacterController>().transform.Rotate(rotation);
        }
        else if (other.tag == "obstacleGoBack")
        {
            rotation = new Vector3(0.0f, 180.0f, 0.0f);
            GetComponent<CharacterController>().transform.Rotate(rotation);
        }
    }
}
