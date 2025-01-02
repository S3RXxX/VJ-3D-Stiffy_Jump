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
        Debug.Log("auxPercentage"+ auxPercentage);
    }
    void FixedUpdate()
    {
        // logica de que pugi el percentatge (legacy code)
        int nBlocks1 = 244;
        int nBlocks2 = 276;
        float k1=1.12f;
        float k2 = 1.08f;
        float increment1 = (100f/nBlocks1)/k1;
        float increment2 = (100f/nBlocks2)/k2;

        if (PlayerPrefs.GetInt("Level")==1)
        {
            auxPercentage += increment1 * playerForward.speed * Time.fixedDeltaTime;
        }
        else
        {
            auxPercentage += increment2 * playerForward.speed * Time.fixedDeltaTime;
        }
        
        currentPercentage = Mathf.FloorToInt(auxPercentage);
        PlayerPrefs.SetInt("currentPercentage", currentPercentage);

        //Debug.Log("%: " + auxPercentage);
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            if (PlayerPrefs.HasKey("SavedHighScore1"))
            {
                if (currentPercentage > PlayerPrefs.GetInt("SavedHighScore1"))
                {
                    PlayerPrefs.SetInt("SavedHighScore1", currentPercentage);
                }
            }
            else
            {
                PlayerPrefs.SetInt("SavedHighScore1", currentPercentage);
            }
        }
        else 
        {
            if (PlayerPrefs.HasKey("SavedHighScore2"))
            {
                if (currentPercentage > PlayerPrefs.GetInt("SavedHighScore2"))
                {
                    PlayerPrefs.SetInt("SavedHighScore2", currentPercentage);
                }
            }
            else
            {
                PlayerPrefs.SetInt("SavedHighScore2", currentPercentage);
            }

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
