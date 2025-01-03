using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerForward : MonoBehaviour
{
    public float speed = 12.5f;
    public float moveSpeed;
    private PathFollower pathFollower;
    private bool isStopped;

    AudioManager audioManager;
    LevelManager levelManager;
    public float timeToDestroy = 0.01f;
    public GameObject explosion;
    public float timeAnimation = 1f;
    PlayerJump playerJump;

    void Start()
    {
        // mesh renderer 1 skin
        int skinSelected = PlayerPrefs.GetInt("PlayerSkin");

        if (transform.gameObject.tag == "Player")
        {
            if (skinSelected == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (skinSelected == 2)
            {
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (skinSelected == 3)
            {
                transform.GetChild(3).gameObject.SetActive(true);
            }
        }
        



        pathFollower = GetComponent<PathFollower>();
        if (speed > 0) 
        {
            moveSpeed = speed;
        }else
        {
            moveSpeed = 5;
        }
            
        isStopped = false;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
        playerJump = GetComponent<PlayerJump>();
    }


    void FixedUpdate()
    {
        if (isStopped && Input.GetKey(KeyCode.W))
        {
            isStopped = false;
            speed = moveSpeed;
        }


        Vector3 move = transform.forward * speed * Time.fixedDeltaTime;

        CollisionFlags flags = GetComponent<CharacterController>().Move(move);
        if (((flags & CollisionFlags.Sides) != 0) && (transform.gameObject.tag == "Player")
            && (!playerJump.GodMode))
        {
            audioManager.PlaySFX(audioManager.breaking);

            // fer apareixer FVX
            Instantiate(explosion, transform.position, transform.rotation);

            levelManager.RestartLevel(timeAnimation);

            // fer explotar el player
            Destroy(gameObject, timeToDestroy);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stop" && !playerJump.GodMode)
        {
            speed = 0f;
            isStopped = true;

        }
    }

    

}
