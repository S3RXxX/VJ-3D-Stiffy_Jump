using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObstacleTriggers : MonoBehaviour
{
    public float timeToDestroy = 0.01f;
    public GameObject explosion;
    public float timeAnimation = 1f;
    AudioManager audioManager;
    LevelManager levelManager;
    PlayerJump playerJump;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
        playerJump = GetComponent<PlayerJump>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spikes" && !playerJump.GodMode) 
        {
            audioManager.PlaySFX(audioManager.breaking);

            // fer apareixer FVX
            Instantiate(explosion, transform.position, transform.rotation);

            levelManager.RestartLevel(timeAnimation);

            // fer explotar el player
            Destroy(gameObject, timeToDestroy);
        }
    }

        
}
