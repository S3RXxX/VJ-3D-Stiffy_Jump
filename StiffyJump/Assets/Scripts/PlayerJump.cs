using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
//using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    public float jumpVel = 7.0f;
    public float jumpHeight = 2.5f;
    public float gravity = 10.0f;
    float velY;
    bool isGrounded;
    AudioManager audioManager;
    private bool GodMode = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velY = 0;
        isGrounded = GetComponent<CharacterController>().isGrounded;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        bool terra = GetComponent<CharacterController>().isGrounded;
        if (terra)
        {
            isGrounded = true;
            velY = 0;
        }

        // if (Input.GetKey(KeyCode.W))
        // {
        //     GodMode = !GodMode;
        //     Debug.Log("Emtrp gpd ,pde");
        // }

        if ((Input.GetKey(KeyCode.Space)) 
            && (isGrounded || GetComponent<CharacterController>().isGrounded))
        {
            audioManager.PlaySFX(audioManager.jumping);

            velY = jumpVel;
            Vector3 move = new Vector3(0f, velY * Time.fixedDeltaTime, 0f);
            //Debug.Log(velY);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);
            isGrounded = false;

        }
        else if (!GetComponent<CharacterController>().isGrounded) //(!isGrounded)
        {
            velY = velY -  Time.fixedDeltaTime * gravity;
            //Debug.Log(velY);
            Vector3 move = new Vector3(0f, velY* Time.fixedDeltaTime, 0f);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);

        }


        //Debug.Log(isGrounded + " " + terra + " " + velY);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered " + other.name);
        if (other.tag == "Jump"
            && GodMode)
        {
            audioManager.PlaySFX(audioManager.jumping);

            velY = jumpVel;
            Vector3 move = new Vector3(0f, velY * Time.fixedDeltaTime, 0f);
            //Debug.Log(velY);
            CollisionFlags flags = GetComponent<CharacterController>().Move(move);
            isGrounded = false;
        }
    }
}
