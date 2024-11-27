using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerJump : MonoBehaviour
{
    public float jumpVel = 8.0f;
    public float jumpHeight = 2.5f;
    public float gravity = 10.0f;
    float velY;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velY = 0;
        isGrounded = GetComponent<CharacterController>().isGrounded;
    }

    void FixedUpdate()
    {
        //Debug.Log("Jump Fixed Update:");
        //Debug.Log(isGrounded);
        if (GetComponent<CharacterController>().isGrounded)
        {
            isGrounded = true;
            velY = 0;
        }


        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) 
            && isGrounded)
        {
            velY = jumpVel;
            Vector3 move = new Vector3(0f, velY * Time.fixedDeltaTime, 0f);
            Debug.Log(velY);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);
            isGrounded = false;

        }
        else if (false)
        {
            // fer mig s a dalt
            velY = velY + Time.fixedDeltaTime * gravity;
            Debug.Log(velY);
            Vector3 move = new Vector3(0f, velY, 0f);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);

        }
        else if (!isGrounded)
        {
            velY = velY -  Time.fixedDeltaTime * gravity;
            Debug.Log(velY);
            Vector3 move = new Vector3(0f, velY* Time.fixedDeltaTime, 0f);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);

        }

    }
}
