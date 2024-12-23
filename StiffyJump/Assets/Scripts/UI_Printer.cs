using UnityEngine;
using TMPro;

public class UI_Printer : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private CollectCoins coins;

    void Start()
    {
        score = 0;
        coins = GetComponent<CollectCoins>();
        scoreText.text = "Score: " + score; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = coins.coins;
        scoreText.text = "Score: " + score;
        //Debug.Log("Coins: " + pathFollower.coins);
    }
}
