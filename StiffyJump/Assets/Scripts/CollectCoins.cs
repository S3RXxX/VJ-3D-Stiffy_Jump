using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public float timeToDestroy = 0.2f;
    public int currentPercentage = 0;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        // logica de que pugui el percentatge
        int increment = 1;

        currentPercentage += increment;
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (currentPercentage > PlayerPrefs.GetInt("SavedHighScore")) {
                PlayerPrefs.SetInt("SavedHighScore", currentPercentage);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", currentPercentage);
        }
        //Debug.Log("SavedHighScore" + PlayerPrefs.GetInt("SavedHighScore"));
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
