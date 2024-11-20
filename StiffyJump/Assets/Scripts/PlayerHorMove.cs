using UnityEngine;
using UnityEditor.Build;

public class PlayerHorMove : MonoBehaviour
{
    //public AudioClip boing;
    int lane = 0;
    float timeToNextMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextMove = 0f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && lane >= 0 && (timeToNextMove <= 0f))
        {
            CollisionFlags flags = GetComponent<CharacterController>().Move(new Vector3(-0.33f, 0f, 0f));
            if ((flags & CollisionFlags.Sides) == 0)
            {
                lane--;
                timeToNextMove = 0.25f;
                //AudioSource.PlayClipAtPoint(boing, transform.position);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && lane <= 0 && (timeToNextMove <= 0f))
        {
            CollisionFlags flags = GetComponent<CharacterController>().Move(new Vector3(0.33f, 0f, 0f));
            if ((flags & CollisionFlags.Sides) == 0)
            {
                lane++;
                timeToNextMove = 0.25f;
                //AudioSource.PlayClipAtPoint(boing, transform.position);
            }
        }
        timeToNextMove -= Time.fixedDeltaTime;
    }
}
