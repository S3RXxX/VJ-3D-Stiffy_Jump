using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public float timeToDestroy = 0.2f;
    public int currentPercentage;
    float auxPercentage;

    AudioManager audioManager;
    PlayerForward playerForward;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        playerForward = transform.GetComponent<PlayerForward>();

    }
    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        auxPercentage = PlayerPrefs.GetInt("currentPercentage");
    }
    void FixedUpdate()
    {
        // logica de que pugi el percentatge
        int nBlocks = 6;
        float increment = 100*(0.678f)/nBlocks;
        auxPercentage += increment * playerForward.speed* Time.fixedDeltaTime;
        currentPercentage = Mathf.FloorToInt(auxPercentage);
        PlayerPrefs.SetInt("currentPercentage", currentPercentage);

        //Debug.Log("%: " + auxPercentage);
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
            PlayerPrefs.SetInt("Coins", coins);
            Destroy(other.gameObject, timeToDestroy);
        }
    }
}
