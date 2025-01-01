using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LevelManager : MonoBehaviour
{
    string sceneToLoad;
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            ShowHighScore();
        }
    }
    //private void FixedUpdate()
    //{
    //    if (PlayerPrefs.HasKey("PlayerSkin")) 
    //    {
    //        Debug.Log(PlayerPrefs.GetInt("PlayerSkin"));
    //    }
            
    //}

    public void RestartLevel(float delayTime)
    {
        StartCoroutine(RestartLevelAfterDelay(delayTime));
    }

    private IEnumerator RestartLevelAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneToLoad); // Restart the current scene
    }

    public void PlayGame()
    {
        Debug.Log("pre if PlayGame");
        if (!PlayerPrefs.HasKey("PlayerSkin")) 
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }
        Debug.Log("PlayGame");
        
        SceneManager.LoadSceneAsync("Level1");
        //SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame2()
    {
        Debug.Log("pre if PlayGame2");
        if (!PlayerPrefs.HasKey("PlayerSkin"))
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }
        Debug.Log("post if PlayGame2");

        // posar pantalla 1 nivell 2
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void toMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void selectP1()
    {
        PlayerPrefs.SetInt("PlayerSkin",1);
    }

    public void selectP2()
    {
        PlayerPrefs.SetInt("PlayerSkin", 2);
    }

    public void selectP3()
    {
        PlayerPrefs.SetInt("PlayerSkin", 3);
    }

    private void ShowHighScore()
    {
        highScoreText.text = "HIGHEST SCORE:\n";
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            highScoreText.text += PlayerPrefs.GetInt("SavedHighScore").ToString();
        }
        else
        {
            highScoreText.text += "0";
        }
        
    }
}
