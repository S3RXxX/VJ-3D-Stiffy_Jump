using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerForward : MonoBehaviour
{
    public float speed = 12.5f;
    private float moveSpeed;
    private PathFollower pathFollower;
    private bool isStopped;

    AudioManager audioManager;
    public LevelManager levelManager;
    public float timeToDestroy = 0.01f;
    public GameObject explosion;
    public float timeAnimation = 1f;

    void Start()
    {
        pathFollower = GetComponent<PathFollower>();
        moveSpeed = speed;
        isStopped = false;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
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
        if ((flags & CollisionFlags.Sides) != 0)
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
        if (other.tag == "Stop")
        {
            speed = 0f;
            isStopped = true;

        }
    }

}
