using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using NUnit.Framework.Interfaces;

public class LevelManager : MonoBehaviour
{
    string sceneToLoad;
    public TextMeshProUGUI highScoreText;
    AudioManager audioManager;
    MapRiseEffect mapRiser;
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            sceneToLoad = "Level1"; //SceneManager.GetActiveScene().name;
        }
        else
        {
            sceneToLoad = "Level9";
        }
            
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            ShowHighScore();
        }
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        mapRiser = GameObject.FindGameObjectWithTag("DynamicMap")?.GetComponent<MapRiseEffect>();

    }
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadSceneAsync("Level1");
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync("Level2");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadSceneAsync("Level3");
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadSceneAsync("Level4");
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                SceneManager.LoadSceneAsync("Level5");
            }
            else if (Input.GetKey(KeyCode.Alpha6))
            {
                SceneManager.LoadSceneAsync("Level6");
            }
            else if (Input.GetKey(KeyCode.Alpha7))
            {
                SceneManager.LoadSceneAsync("Level7");
            }
            else if (Input.GetKey(KeyCode.Alpha8))
            {
                SceneManager.LoadSceneAsync("Level8");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadSceneAsync("Level9");
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync("Level10");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadSceneAsync("Level11");
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadSceneAsync("Level12");
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                SceneManager.LoadSceneAsync("Level13");
            }
            else if (Input.GetKey(KeyCode.Alpha6))
            {
                SceneManager.LoadSceneAsync("Level14");
            }
            else if (Input.GetKey(KeyCode.Alpha7))
            {
                SceneManager.LoadSceneAsync("Level15");
            }
            else if (Input.GetKey(KeyCode.Alpha8))
            {
                SceneManager.LoadSceneAsync("Level16");
            }

        }

        if (Input.GetKey(KeyCode.Y))
        {

            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadSceneAsync("Level1");
            PlayerPrefs.SetInt("currentPercentage", 0);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            PlayerPrefs.SetInt("Level", 2);
            SceneManager.LoadSceneAsync("Level9");
            PlayerPrefs.SetInt("currentPercentage", 0);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadSceneAsync("Main Menu");
            PlayerPrefs.SetInt("currentPercentage", 0);
        }
        else if (Input.GetKey(KeyCode.Escape)) 
        {
            Application.Quit();
        }

    }

    public void RestartLevel(float delayTime)
    {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("currentPercentage", 0);
        mapRiser.Lower();
        StartCoroutine(RestartLevelAfterDelay(delayTime));
    }

    private IEnumerator RestartLevelAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadSceneAsync(sceneToLoad); // Restart the current scene
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        //Debug.Log("pre if PlayGame");
        if (!PlayerPrefs.HasKey("PlayerSkin")) 
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }

        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("currentPercentage", 0);

        SceneManager.LoadSceneAsync("Level1");
        //SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame2()
    {
        //Debug.Log("pre if PlayGame2");
        PlayerPrefs.SetInt("Level", 2);
        if (!PlayerPrefs.HasKey("PlayerSkin"))
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }

        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("currentPercentage", 0);

        // posar pantalla 1 nivell 2
        SceneManager.LoadSceneAsync("Level9");
    }

    public void toMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void selectP1()
    {
        audioManager.PlaySFX(audioManager.meow);
        PlayerPrefs.SetInt("PlayerSkin",1);

    }

    public void selectP2()
    {
        audioManager.PlaySFX(audioManager.ugh);
        PlayerPrefs.SetInt("PlayerSkin", 2);
    }

    public void selectP3()
    {
        audioManager.PlaySFX(audioManager.chicken);
        PlayerPrefs.SetInt("PlayerSkin", 3);
    }

    private void ShowHighScore()
    {
        highScoreText.text = "HIGHEST SCORE:\n";
        highScoreText.text += "Level1: ";
        if (PlayerPrefs.HasKey("SavedHighScore1"))
        {
            highScoreText.text += PlayerPrefs.GetInt("SavedHighScore1").ToString();
        }
        else
        {
            highScoreText.text += "0";
        }

        highScoreText.text += "\nLevel2: ";
        if (PlayerPrefs.HasKey("SavedHighScore2"))
        {
            highScoreText.text += PlayerPrefs.GetInt("SavedHighScore2").ToString();
        }
        else
        {
            highScoreText.text += "0";
        }

    }

    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        if ("Level8" == SceneManager.GetActiveScene().name)
        {

            //PlayerPrefs.SetInt("Level", 2);
            PlayerPrefs.SetInt("currentPercentage", 0);
            sceneIndex = 0;
        }
        mapRiser.Lower();
        //SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadLevelAfterDelay(0.5f, sceneIndex));

    }

    private IEnumerator LoadLevelAfterDelay(float delayTime, int iToLoad)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadSceneAsync(iToLoad); // Restart the current scene
    }


    public void ResetScores()
    {
        PlayerPrefs.SetInt("SavedHighScore1", 0);
        PlayerPrefs.SetInt("SavedHighScore2", 0);
        PlayerPrefs.Save();
        ShowHighScore();
    }
}
