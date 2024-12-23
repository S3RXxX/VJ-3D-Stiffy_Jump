using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PathFollower : MonoBehaviour
{
    //public Vector3 outVelocity;
    
    private Vector3 rotation;
    private void Start()
    {
        //outVelocity = transform.forward;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered " + other.name);
        if (other.tag == "turnL")
        {
            //outVelocity = new Vector3();
            rotation = new Vector3(0.0f, -90.0f, 0.0f);
            GetComponent<CharacterController>().transform.Rotate(rotation);
        }
        else if (other.tag == "turnR")
        {
            //outVelocity = new Vector3();
            rotation = new Vector3(0.0f, 90.0f, 0.0f);
            GetComponent<CharacterController>().transform.Rotate(rotation);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("In " + other.name);
    }
}
