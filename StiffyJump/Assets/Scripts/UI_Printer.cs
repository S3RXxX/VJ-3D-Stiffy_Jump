using UnityEngine;
using TMPro;

public class UI_Printer : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int coin;
    private int percentage;
    private CollectCoins coins;


    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<TextMeshProUGUI>();
        
        coins = GetComponent<CollectCoins>();
        coin = coins.coins;
        percentage = coins.currentPercentage;
        scoreText.text = "Score: " + coin;
        scoreText.text += "\n";
        scoreText.text += "Percentage: " + percentage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coin = coins.coins;
        percentage = coins.currentPercentage;
        scoreText.text = "Score: " + coin;
        scoreText.text += "\n";
        scoreText.text += "Percentage: " + percentage;

        coins.UpdateHighScore();
        
    }
}
