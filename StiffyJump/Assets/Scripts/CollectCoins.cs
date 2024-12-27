using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public float timeToDestroy = 0.2f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            audioManager.PlaySFX(audioManager.coining);
            coins += 1;
            Destroy(other.gameObject, timeToDestroy);
        }
    }
}
