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
    public bool GodMode = false;
    private float timeToNextMove;
    PlayerForward playerForward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextMove = 0f;
        velY = 0;
        isGrounded = GetComponent<CharacterController>().isGrounded;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //GodMode = true;
        GodMode = PlayerPrefs.GetInt("GodMode")==1;
    }

    void FixedUpdate()
    {
        
        bool terra = GetComponent<CharacterController>().isGrounded;
        if (terra)
        {
            isGrounded = true;
            velY = 0;
        }

        if (Input.GetKey(KeyCode.G) && (timeToNextMove <= 0f))
        {
            playerForward = GetComponent<PlayerForward>();

            GodMode = !GodMode;

            if (GodMode)
            {
                playerForward.speed = playerForward.moveSpeed;
                PlayerPrefs.SetInt("GodMode", 1);
            }
            else
            {
                PlayerPrefs.SetInt("GodMode", 0);
            }

            timeToNextMove = 0.25f;
        }
        timeToNextMove -= Time.fixedDeltaTime;

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
